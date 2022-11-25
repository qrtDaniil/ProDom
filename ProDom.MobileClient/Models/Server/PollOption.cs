using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models.Server
{
    public class PollOption
    {
        public int Id { get; set; }

        public int PollId { get; set; }
        public Poll Poll { get; set; }
        public string Title { get; set; }

        public int Votes { get; set; }
    }
}
