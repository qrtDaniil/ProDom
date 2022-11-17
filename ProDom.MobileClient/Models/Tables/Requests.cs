using SQLite;

namespace ProDom.MobileClient.Models.Tables
{
    public class Requests
    {
        [PrimaryKey, AutoIncrement]
        public int RequestId { get; set; }
        public string ImageResource { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public bool isDecided { get; set; } = false;

        public int dialogId { get; set; }
    }
}
