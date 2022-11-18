namespace ProDom.ApiServer.Models
{
    public class BaseModel
    {
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
