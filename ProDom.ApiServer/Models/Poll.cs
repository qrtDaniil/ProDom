using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class Poll : BaseModel
    {
        public int Id { get; set; }

        public List<PollOption> PollsOptions { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        [MaxLength(60)]
        public string Title { get; set; }

        public string Body { get; set; }

        public int Duration { get; set; }

        public Poll(int id, int creatorId, string title, string body, int duration)
        {
            Id = id;
            CreatorId = creatorId;
            Title = title;
            Body = body;
            Duration = duration;
        }
    }
}
