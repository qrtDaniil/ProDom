using SQLite;

namespace ProDom.MobileClient.Models.Tables
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int userId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string ImageResource { get; set; } = "user_no_image.png";
        public string Password { get; set; }

        public bool IsHasMessages { get; set; } = false;
    }
}