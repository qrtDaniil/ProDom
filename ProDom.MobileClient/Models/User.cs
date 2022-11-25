using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models
{
    public class User
    {
        public int? Id { get; set; }

        public List<Poll>? Polls { get; set; }

        public int? PersonalAccountId { get; set; }

        public int? RoleId { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public byte[]? ProfilePicture { get; set; }

        public string Password { get; set; }
    }
}
