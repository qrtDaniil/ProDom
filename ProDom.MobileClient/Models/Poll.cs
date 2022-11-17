using SQLite;

namespace ProDom.MobileClient.Models
{
    public class Poll
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string imageResource { get; set; }
        public string description { get; set; }

        public DateTime dateStart { get; set; }
        public TimeSpan timeConducting { get; set; }

        public string status { get; set; }
        public string userAnswer { get; set; }

    }
}
