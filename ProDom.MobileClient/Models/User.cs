using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models
{
    public class User
    {
        public enum ROLE { HEADMAN, CITIZEN }

        public int userId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string ImageResourse { get; set; }
        public ROLE Role { get; set; }
        public List<int> FriendsID { get; set; }

        public IList<Models.Message> Messages { get; set; }
        public int NotReadedCount { get; private set; }

        public User()
        {
        }
    }
}
