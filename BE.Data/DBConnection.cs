using BE.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace BE.Data
{
    public class DBConnection: IDisposable
    {
        //An object of JobDB Connection.
        private static DBConnection DBCon;
        //Variable to store the connection details
        protected SqlConnection Connection;
        //Variable to store the SQL Command
        protected SqlCommand Command;
        //Variable to store the SQL Adapter
        protected SqlDataAdapter Adapter;

        /// <summary>
        /// Default Constructor. We are making it private so that we have control over the number of objects created
        /// Making it private, makes sure that external classes does not have access to this method
        /// </summary>
        public DBConnection()
        {
            Connection = new SqlConnection();
            Command = Connection.CreateCommand();
            Adapter = new SqlDataAdapter();
            //Initialize the connection string of the SQL Connection object
            Connection.ConnectionString = @WebConfigurationManager.ConnectionStrings["BE"].ConnectionString;
        }

        /// <summary>
        /// This method is used to open connection. This method checks if the connection is already open.
        /// If yes, use the same connection. Else create a new connection and return.
        /// </summary>
        protected bool OpenJobDBConnection()
        {
            try
            {
                if (!Connection.State.ToString().ToUpper().Equals("OPEN"))
                {
                    Connection.Open();
                }
                return true;
            }
            //Catch all SQL exception and log the exception and return false, indication failure in connection creation
            catch (SqlException ex)
            {
                ExceptionLogging.LogExceptiontoLogFile(ex);
                return false;
            }
            //Catch all exception and log the exception and return false, indication failure in connection creation
            catch (Exception ex)
            {
                ExceptionLogging.LogExceptiontoLogFile(ex);
                return false;
            }
        }

        /// <summary>
        /// This method is used to close connection. This method checks if the connection is open.
        /// If yes, then close. Else no action is performed.
        /// </summary>
        /// <returns></returns>
        protected bool CloseJobDBConnection()
        {
            try
            {
                if (Connection.State.ToString().ToUpper().Equals("OPEN"))
                {
                    Connection.Close();
                }
                return true;
            }
            //Catch all SQL exception and log the exception and return false, indication failure in connection closure
            catch (SqlException ex)
            {
                ExceptionLogging.LogExceptiontoLogFile(ex);
                return false;
            }
            //Catch all exception and log the exception and return false, indication failure in connection closure
            catch (Exception ex)
            {
                ExceptionLogging.LogExceptiontoLogFile(ex);
                return false;
            }
        }

        /// <summary>
        /// This method is used to execute a SQL Command and return dataset
        /// The method does not handle exceptions, the exceptions are thrown to the calling method.
        /// </summary>
        /// <param name="strSqlCommandText">The SQL Command that has to be executed</param>
        /// <returns>The dataset obtained after executing the sql command</returns>
        public DataSet ExecuteReader(string strSqlCommandText, SqlParameter[] sqlParams)
        {
            try
            {
                DataSet dsResultSet = new DataSet();
                Command.CommandText = strSqlCommandText;
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        Command.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }
                if (this.OpenJobDBConnection())
                {
                    Adapter.SelectCommand = Command;
                    Adapter.Fill(dsResultSet);
                    return dsResultSet;
                }
                else
                {
                    throw new Exception(AppConstants.ErrMsgUnabletoOpenSqlConnection);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseJobDBConnection();
            }
        }

        /// <summary>
        /// This method is used to execute the sql command and return an object
        ///The method does not handle exceptions, the exceptions are thrown to the calling method.
        /// </summary>
        /// <param name="strSqlCommandText">The SQL Command that has to be executed</param>
        /// <returns>The object after executing the sql command</returns>
        public Object ExecuteScalar(string strSqlCommandText, SqlParameter[] sqlParams)
        {
            try
            {
                Object obj = new object();
                Command.CommandText = strSqlCommandText;
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        Command.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }
                if (this.OpenJobDBConnection())
                {
                    obj = Command.ExecuteScalar();
                    return obj;
                }
                else
                {
                    throw new Exception(AppConstants.ErrMsgUnabletoOpenSqlConnection);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseJobDBConnection();
            }
        }

        /// <summary>
        /// This method is used to execute a non query. Does not return an result.
        /// The method does not handle exceptions, the exceptions are thrown to the calling method.
        /// </summary>
        /// <param name="strSqlCommandText">The SQL Command that has to be executed</param>
        public void ExecuteNonQuery(String strSqlCommandText, SqlParameter[] sqlParams)
        {
            try
            {
                Command.CommandText = strSqlCommandText;
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Clear();
                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        Command.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }
                if (this.OpenJobDBConnection())
                {
                    Command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception(AppConstants.ErrMsgUnabletoOpenSqlConnection);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseJobDBConnection();
            }
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
        // ~DBConnection() {
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
