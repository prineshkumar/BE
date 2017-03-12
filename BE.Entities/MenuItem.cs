using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Entities
{
    public class MenuItem
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string MenuImage { get; set; }
        public string MenuStatus { get; set; }
        public string URL { get; set; }
    }
}
