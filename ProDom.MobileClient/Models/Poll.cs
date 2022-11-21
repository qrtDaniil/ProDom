using SQLite;

namespace ProDom.MobileClient.Models
{
    public class Poll
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DateStart { get; set; }
        public TimeSpan TimeConducting { get; set; }

        public string Status { get; set; }
        public string UserAnswer { get; set; }

    }
}
