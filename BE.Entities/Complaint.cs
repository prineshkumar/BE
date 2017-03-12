using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public int TenantID { get; set; }
        public string ComplaintDescription { get; set; }
        public DateTime ComplaintRaisedDate { get; set; }
        public string ComplaintStatus { get; set; }
        public DateTime ComplaintLastModifiedDate { get; set; }
        public Tenant TenantDetails { get; set; }
        public Branch BranchDetails { get; set; }

        public Complaint()
        {
            TenantDetails = new Tenant();
            BranchDetails = new Branch();
        }
    }
}
