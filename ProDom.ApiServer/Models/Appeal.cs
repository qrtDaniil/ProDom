namespace ProDom.ApiServer.Models
{
    public class Appeal
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string Category { get; set; }

        public string Body { get; set; }

        public string Status { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Appeal(int id, int userId, string category, string body, string status, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Body = body;
            Status = status;
            UpdatedAt = updatedAt;
            CreatedAt = createdAt;
        }
    }
}