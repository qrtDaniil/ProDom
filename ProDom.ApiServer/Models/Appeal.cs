using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class Appeal : BaseModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        [MaxLength(90)]
        public string Category { get; set; }

        public string Body { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public Appeal(int id, int senderId, string category, string body, string status)
        {
            Id = id;
            SenderId = senderId;
            Category = category;
            Body = body;
            Status = status;
        }
    }
}
