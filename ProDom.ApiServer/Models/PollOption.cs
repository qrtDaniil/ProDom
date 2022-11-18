using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class PollOption : BaseModel
    {
        public int Id { get; set; }

        public int PollId { get; set; }
        public Poll Poll { get; set; }

        [MaxLength(60)]
        public string Title { get; set; }

        public int Votes { get; set; }

        public PollOption(int id, int pollId, string title, int votes)
        {
            Id = id;
            PollId = pollId;
            Title = title;
            Votes = votes;
        }
    }
}
