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
    public class UserOperations : IDisposable
    {
        public User GetUserDetails(string userName, string password)
        {
            User _userDetails = null;
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName:"UserName",value:userName),
                                //new SqlParameter(parameterName:"Password",value:Encrypt.DecryptString(password)) };
                                new SqlParameter(parameterName:"Password",value:password) };

                DataSet dsUserDetails = dbCon.ExecuteReader("BE_Get_LoginUserDetails", sqlParams);
                if (dsUserDetails != null && dsUserDetails.Tables.Count > 0 && dsUserDetails.Tables[0].Rows.Count > 0)
                {
                    _userDetails = new User();
                    _userDetails.ID = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["ID"]);
                    _userDetails.LoginName = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["LoginName"]);
                    _userDetails.TenantID = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["TenantID"]);
                    _userDetails.EmployeeID = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["EmployeeID"]);
                    _userDetails.DesignationID = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["DesignationID"]);
                    _userDetails.Designation = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["DesignationName"]);
                }
            }
            return _userDetails;
        }

        public Employee GetEmployeeDetails(int EmployeeID)
        {
            Employee _employeeDetails = null;
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName: "EmployeeID", value: EmployeeID) };
                DataSet dsUserDetails = dbCon.ExecuteReader("BE_Get_EmployeeDetailsbyID", sqlParams);
                if (dsUserDetails != null && dsUserDetails.Tables.Count > 0 && dsUserDetails.Tables[0].Rows.Count > 0)
                {
                    _employeeDetails = new Employee();
                    _employeeDetails.EmployeeID = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["EmployeeID"]);
                    _employeeDetails.EmployeeName = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["EmployeeName"]);
                    _employeeDetails.EmployeeEmail = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["EmployeeEmail"]);
                    _employeeDetails.EmployeePhoneNumber = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["EmployeePhoneNumber"]);
                    if (dsUserDetails.Tables[0].Rows[0]["EmployeeDOB"] != DBNull.Value)
                        _employeeDetails.EmployeeDOB = Convert.ToDateTime(dsUserDetails.Tables[0].Rows[0]["EmployeeDOB"]);
                    _employeeDetails.EmployeeSalary = Convert.ToDouble(dsUserDetails.Tables[0].Rows[0]["EmployeeSalary"]);
                    _employeeDetails.EmployeeStatus = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["EmployeeStatus"]);
                    _employeeDetails.LoginPassword = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["LoginPassword"]);

                    _employeeDetails.BranchDetails.BranchID = Convert.ToInt32(dsUserDetails.Tables[0].Rows[0]["BranchID"]);
                    _employeeDetails.BranchDetails.City = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["City"]);
                    _employeeDetails.BranchDetails.BranchName = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["BranchName"]);
                    _employeeDetails.BranchDetails.BranchAddress = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["BranchAddress"]);
                    _employeeDetails.BranchDetails.PhoneNumber = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["PhoneNumber"]);
                    _employeeDetails.BranchDetails.EmailAddress = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["EmailAddress"]);
                    _employeeDetails.BranchDetails.Gender = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["Gender"]);
                    _employeeDetails.BranchDetails.BranchStatus = Convert.ToString(dsUserDetails.Tables[0].Rows[0]["BranchStatus"]);
                }
            }
            return _employeeDetails;
        }

        public Tenant GetTenantDetails(int TenantID)
        {
            Tenant _tenantDetails = null;
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName: "TenantID", value: TenantID) };
                DataSet dsTenantDetails = dbCon.ExecuteReader("BE_Get_TenantDetailsbyID", sqlParams);
                if (dsTenantDetails != null && dsTenantDetails.Tables.Count > 0 && dsTenantDetails.Tables[0].Rows.Count > 0)
                {
                    _tenantDetails = new Tenant();
                    _tenantDetails.TenantID = Convert.ToInt32(dsTenantDetails.Tables[0].Rows[0]["TenantID"]);
                    _tenantDetails.TenantName = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["TenantName"]);
                    _tenantDetails.BranchDetails.BranchID = Convert.ToInt32(dsTenantDetails.Tables[0].Rows[0]["BranchID"]);
                    _tenantDetails.BranchDetails.City = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["City"]);
                    _tenantDetails.BranchDetails.BranchName = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["BranchName"]);
                    _tenantDetails.BranchDetails.BranchAddress = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["BranchAddress"]);
                    _tenantDetails.BranchDetails.PhoneNumber = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["PhoneNumber"]);
                    _tenantDetails.BranchDetails.EmailAddress = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["EmailAddress"]);
                    _tenantDetails.BranchDetails.Gender = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["Gender"]);
                    _tenantDetails.BranchDetails.BranchStatus = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["BranchStatus"]);
                    _tenantDetails.RoomNumber = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["RoomNo"]);
                    if (dsTenantDetails.Tables[0].Rows[0]["TenantDOB"] != DBNull.Value)
                        _tenantDetails.DOB = Convert.ToDateTime(dsTenantDetails.Tables[0].Rows[0]["TenantDOB"]);
                    if (dsTenantDetails.Tables[0].Rows[0]["DateofJoin"] != DBNull.Value)
                        _tenantDetails.DOJ = Convert.ToDateTime(dsTenantDetails.Tables[0].Rows[0]["DateofJoin"]);
                    if (dsTenantDetails.Tables[0].Rows[0]["DateofExit"] != DBNull.Value)
                        _tenantDetails.DOE = Convert.ToDateTime(dsTenantDetails.Tables[0].Rows[0]["DateofExit"]).ToString("yyyy-MM-dd");
                    _tenantDetails.PaymentDate = Convert.ToDateTime(dsTenantDetails.Tables[0].Rows[0]["PaymentDate"]);
                    _tenantDetails.MonthofPayment = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["PaymentMonth"]);
                    _tenantDetails.MonthlyRent = Convert.ToDouble(dsTenantDetails.Tables[0].Rows[0]["Rent"]);
                    _tenantDetails.Name = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["TenantName"]);
                    _tenantDetails.LoginPassword = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["LoginPassword"]);
                    _tenantDetails.Email = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["TenantEmail"]);
                    _tenantDetails.PhoneNo = Convert.ToString(dsTenantDetails.Tables[0].Rows[0]["TenantPhoneNumber"]);
                }
            }
            return _tenantDetails;
        }

        public void UpdateTenantDetails(Tenant _tenant)
        {
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] {new SqlParameter(parameterName: "TenantID", value: _tenant.TenantID)
                    ,new SqlParameter(parameterName: "TenantName", value: _tenant.Name)
                    ,new SqlParameter(parameterName: "TenantEmail", value: _tenant.Email)
                    ,new SqlParameter(parameterName: "TenantPhoneNumber", value: _tenant.PhoneNo)
                    ,new SqlParameter(parameterName: "LoginPassword", value: _tenant.LoginPassword)};
                dbCon.ExecuteReader("BE_Update_TenantDetailsbyID", sqlParams);
            }
        }

        public void UpdateEmployeeDetails(Employee _employee)
        {
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] {new SqlParameter(parameterName: "EmployeeID", value: _employee.EmployeeID)
                    ,new SqlParameter(parameterName: "EmployeeName", value: _employee.EmployeeName)
                    ,new SqlParameter(parameterName: "EmployeeEmail", value: _employee.EmployeeEmail)
                    ,new SqlParameter(parameterName: "EmployeePhoneNumber", value: _employee.EmployeePhoneNumber)
                    ,new SqlParameter(parameterName: "LoginPassword", value: _employee.LoginPassword)};
                dbCon.ExecuteReader("BE_Update_EmployeeDetailsbyID", sqlParams);
            }
        }

        public void UpdateTenantExitDate(Tenant _tenant)
        {
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName: "TenantID", value: _tenant.TenantID)
                    ,new SqlParameter(parameterName: "DateofExit", value: _tenant.DOE)};
                dbCon.ExecuteReader("BE_Update_TenantExitDatebyID", sqlParams);
            }
        }

        public IEnumerable<Receipt> GetReceiptDetails(int tenantID)
        {
            List<Receipt> _receiptItems = null;
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName: "TenantID", value: tenantID) };

                DataSet dsReceiptDetails = dbCon.ExecuteReader("BE_Get_RentReceiptDetails", sqlParams);
                if (dsReceiptDetails != null && dsReceiptDetails.Tables.Count > 0 && dsReceiptDetails.Tables[0].Rows.Count > 0)
                {
                    _receiptItems = new List<Receipt>();
                    Receipt _receipt = null;
                    foreach (DataRow drReceipt in dsReceiptDetails.Tables[0].Rows)
                    {
                        _receipt = new Receipt();
                        _receipt.PaymentID = Convert.ToInt32(drReceipt["PaymentID"]);
                        _receipt.Month = Convert.ToString(drReceipt["MonthofPayment"]);
                        _receipt.ReceiptType = Convert.ToString(drReceipt["PaymentPurpose"]);
                        _receipt.DownloadLink = Convert.ToString(drReceipt["ReceiptName"]);
                        _receiptItems.Add(_receipt);
                    }
                }
            }
            return _receiptItems;
        }

        public IEnumerable<Complaint> GetComplaintDetails(int tenantID)
        {
            List<Complaint> _complaintItems = null;
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName: "TenantID", value: tenantID) };

                DataSet dsComplaintDetails = dbCon.ExecuteReader("BE_Get_ComplaintDetails", sqlParams);
                if (dsComplaintDetails != null && dsComplaintDetails.Tables.Count > 0 && dsComplaintDetails.Tables[0].Rows.Count > 0)
                {
                    _complaintItems = new List<Complaint>();
                    Complaint _complaint = null;
                    foreach (DataRow drComplaint in dsComplaintDetails.Tables[0].Rows)
                    {
                        _complaint = new Complaint();
                        _complaint.ComplaintID = Convert.ToInt32(drComplaint["ComplaintID"]);
                        _complaint.TenantID = Convert.ToInt32(drComplaint["TenantID"]);
                        _complaint.ComplaintDescription = Convert.ToString(drComplaint["ComplaintDescription"]);
                        _complaint.ComplaintRaisedDate = Convert.ToDateTime(drComplaint["ComplaintRaisedDate"]);
                        _complaint.ComplaintStatus = Convert.ToString(drComplaint["ComplaintStatus"]);
                        _complaint.ComplaintLastModifiedDate = Convert.ToDateTime(drComplaint["ComplaintLastModifiedDate"]);
                        _complaintItems.Add(_complaint);
                    }
                }
            }
            return _complaintItems;
        }

        public bool SaveComplaint(Complaint _complaint)
        {
            bool isSuccessful = true;
            try
            {
                using (DBConnection dbCon = new DBConnection())
                {
                    SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName:"TenantID",value:_complaint.TenantID)
                    ,new SqlParameter(parameterName:"ComplaintDescription",value:_complaint.ComplaintDescription)
                    ,new SqlParameter(parameterName:"ComplaintStatus",value:_complaint.ComplaintStatus)
                    ,new SqlParameter(parameterName:"ComplaintID",value:_complaint.ComplaintID)};
                    dbCon.ExecuteNonQuery("BE_Insert_ComplaintDetails", sqlParams);
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
            }
            return isSuccessful;
        }

        public IEnumerable<Complaint> GetComplaintDetailsByEmployee(int employeeID)
        {
            List<Complaint> _complaintItems = null;
            using (DBConnection dbCon = new Data.DBConnection())
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter(parameterName: "employeeID", value: employeeID) };

                DataSet dsComplaintDetails = dbCon.ExecuteReader("BE_Get_ComplaintDetailsByEmployee", sqlParams);
                if (dsComplaintDetails != null && dsComplaintDetails.Tables.Count > 0 && dsComplaintDetails.Tables[0].Rows.Count > 0)
                {
                    _complaintItems = new List<Complaint>();
                    Complaint _complaint = null;
                    foreach (DataRow drComplaint in dsComplaintDetails.Tables[0].Rows)
                    {
                        _complaint = new Complaint();
                        _complaint.ComplaintID = Convert.ToInt32(drComplaint["ComplaintID"]);
                        _complaint.TenantID = Convert.ToInt32(drComplaint["TenantID"]);
                        _complaint.TenantDetails = new Tenant();
                        _complaint.TenantDetails.TenantID = Convert.ToInt32(drComplaint["TenantID"]);
                        _complaint.TenantDetails.TenantName = Convert.ToString(drComplaint["TenantName"]);
                        _complaint.TenantDetails.RoomNumber = Convert.ToString(drComplaint["RoomNo"]);
                        _complaint.BranchDetails.BranchID = Convert.ToInt32(drComplaint["BranchID"]);
                        _complaint.BranchDetails.BranchName = Convert.ToString(drComplaint["BranchName"]);
                        _complaint.ComplaintDescription = Convert.ToString(drComplaint["ComplaintDescription"]);
                        _complaint.ComplaintRaisedDate = Convert.ToDateTime(drComplaint["ComplaintRaisedDate"]);
                        _complaint.ComplaintStatus = Convert.ToString(drComplaint["ComplaintStatus"]);
                        _complaint.ComplaintLastModifiedDate = Convert.ToDateTime(drComplaint["ComplaintLastModifiedDate"]);
                        _complaintItems.Add(_complaint);
                    }
                }
            }
            return _complaintItems;
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
        // ~UserOperations() {
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
