using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models.Visual
{
    public class MessageInPrivateChats
    {
        public int DialogID { get; set; }
        public int MessageID { get; set; }
        public string LastMessageText { get; set; }
        public int notReadedCount { get; set; }
        public bool isHasNotReaded { get; set; }
        public bool isHasNotNotReaded { get; set; }
        public string ImageStatusResource { get; set; }
        public string TimeBeforeLastMessage { get; set; }

        public string Title { get; set; }
        public string UserImageResource { get; set; }
    }
}
