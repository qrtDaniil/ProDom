using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models.Visual
{
    public class MessageInChat
    {
        public int SenderID { get; set; }
        public int ID { get; set; }
        public string Message { get; set; }
        public string MessageFrom { get; set; }
        public string UserImage { get; set; }

        public string HorizontalOption { get; set; }
        public Color Background { get; set; }
        public string timeSended { get; set; }
        public string statusImage { get; set; } 
        public int GridColumnMessage { get; set; }
        public int GridColumnImage { get; set; }
    }
}
