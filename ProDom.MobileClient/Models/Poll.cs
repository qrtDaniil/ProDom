using SQLite;

namespace ProDom.MobileClient.Models
{
    public class Poll
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

    }
}
