using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models
{
    public class Message
    {
        //UserInfo
        public int userId { get; set; } //from server
        public string userName { get; set; } //from server
        public string imageResource { get; set; } //from server
        //MessageInfo
        public string status { get; set; } //from server
        public string message { get; set; } //from server
        public DateTime sendedAt { get; set; } //from server
        public string timeBeforelastMessage { get; set; } 
        public bool notReadedLabelVisibility { get; set; } 
        public string messageFrom { get; set; } //from server
        public int notReadedCount { get; set; } //from server
        public string statusImageResouce { get; set; }

    }
}
