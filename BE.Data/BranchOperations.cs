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
    public class BranchOperations : IDisposable
    {
        public IEnumerable<Branch> GetBranchDetailsByEmployee(int EmployeeID)
        {
            List<Branch> _branchDetails = null;
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName: "EmployeeID", value: EmployeeID) };
                DataSet dsBranchDetails = dbCon.ExecuteReader("BE_Get_BranchDetailsbyEmployee", sqlParams);
                if (dsBranchDetails != null && dsBranchDetails.Tables.Count > 0 && dsBranchDetails.Tables[0].Rows.Count > 0)
                {
                    _branchDetails = new List<Branch>();
                    Branch _branch = null;
                    foreach (DataRow drBranch in dsBranchDetails.Tables[0].Rows)
                    {
                        _branch = new Branch();
                        _branch.BranchID = Convert.ToInt32(drBranch["BranchID"]);
                        _branch.BranchName = Convert.ToString(drBranch["BranchName"]);
                        _branch.City = Convert.ToString(drBranch["City"]);
                        _branch.BranchAddress = Convert.ToString(drBranch["BranchAddress"]);
                        _branch.EmailAddress = Convert.ToString(drBranch["EmailAddress"]);
                        _branch.Gender = Convert.ToString(drBranch["Gender"]);
                        _branch.PhoneNumber = Convert.ToString(drBranch["PhoneNumber"]);
                        _branch.BranchStatus = Convert.ToString(drBranch["BranchStatus"]);
                        _branchDetails.Add(_branch);
                    }
                }
            }
            return _branchDetails;
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
        // ~BranchOperations() {
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
