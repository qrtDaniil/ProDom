using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class PersonalAccount : BaseModel
    {
        public int Id { get; set; }

        public List<User> Users { get; set; }

        [MaxLength(40)]
        public string AccountCode { get; set; }

        public int Points { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public PersonalAccount(int id, string accountCode, int points, int addressId)
        {
            Id = id;
            AccountCode = accountCode;
            Points = points;
            AddressId = addressId;
        }
    }
}
