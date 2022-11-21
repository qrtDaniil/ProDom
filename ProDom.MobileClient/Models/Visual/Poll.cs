using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models.Visual
{
    public class Poll
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserVoice { get; set; }
        public string TimeSpanClose { get; set; }
        public bool IsVisible { get; set; }

        public string VoicedStatus { get; set; }
        public Color VoicedStatusColor { get; set; }

    }
}
