using BE.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Data
{
    public class MenuOperations : IDisposable
    {
        public IEnumerable<MenuItem> GetMenuByDesignation(int designationID)
        {
            List<MenuItem> _menuItems = null;
            using (DBConnection dbcon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] {new SqlParameter(parameterName:"DesignationID"
                                            ,value:designationID)};
                DataSet dsMenuDetails = dbcon.ExecuteReader("BE_Get_MenuAccessByDesignation", sqlParams);
                if (dsMenuDetails != null && dsMenuDetails.Tables.Count > 0 && dsMenuDetails.Tables[0].Rows.Count > 0)
                {
                    _menuItems = (from row in dsMenuDetails.Tables[0].AsEnumerable()
                                  select new MenuItem
                                  {
                                      MenuID = row.Field<int>("MenuID"),
                                      MenuName = row.Field<string>("MenuName"),
                                      MenuImage = row.Field<string>("MenuImage"),
                                      MenuStatus = row.Field<string>("MenuStatus"),
                                      URL=row.Field<string>("URL"),
                                  }).ToList();
                }
            }
            return _menuItems;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MenuOperations() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
