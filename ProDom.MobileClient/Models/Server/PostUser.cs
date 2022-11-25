using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models.Server
{
    public class PostUser
    {
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public PostPersonalAccount? PersonalAccount { get; set; }
    }
}
