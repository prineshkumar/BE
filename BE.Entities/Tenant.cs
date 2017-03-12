using System;

namespace BE.Entities
{
    public class Tenant
    {
        public int TenantID { get; set; }
        public string TenantName { get; set; }
        public Branch BranchDetails { get; set; }
        public string RoomNumber { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string DOE { get; set; }
        public DateTime PaymentDate { get; set; }
        public string MonthofPayment { get; set; }
        public double MonthlyRent { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string LoginPassword { get; set; }

        public Tenant()
        {
            BranchDetails = new Branch();
        }
    }
}
