using ProDom.MobileClient.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProDom.MobileClient.Models
{
    public class CurrentUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string ImageResource { get; set; }
        public string Adress { get; set; }

        public CurrentUser()
        {
            Services.Server ser = new();
            Services.ServerGets server = new(ser);
            if (server.IsHasConnection() && Preferences.Default.Get("API", "0") != "0")
            {
                var user = server.GetCurrentUserInfo();

                Name = user.Name;
                Surname = user.Surname;
                Patronymic = user.Patronymic;
                ImageResource = user.ImageResource!= null ? user.ImageResource : "user_no_image.png";
                Adress = user.Adress;
            }
        }

    }
}
