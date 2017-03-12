using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class Receipt
    {
        public int PaymentID { get; set; }
        public string Month { get; set; }
        public string ReceiptType { get; set; }
        public string DownloadLink { get; set; }
    }
}
