using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string LoginName { get; set; }
        public int TenantID { get; set; }
        public int EmployeeID { get; set; }
        public int DesignationID { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string LoginPassword { get; set; }
    }
}
