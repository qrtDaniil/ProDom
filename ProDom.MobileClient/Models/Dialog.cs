using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models
{
    public class Dialog
    {
        public string Title { get; set; }
        public int DialogID { get; set; }
        public string Type { get; set; }
        public List<int> MembersID { get; set; }

    }
}
