using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class PersonalAccount
    {
        public int Id { get; set; }

        public List<User> Users { get; set; } = null!;

        [MaxLength(40)]
        public string AccountCode { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PersonalAccount(int id, string accountCode, int addressId, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            AccountCode = accountCode;
            AddressId = addressId;
            UpdatedAt = DateTime.Now;
            CreatedAt = DateTime.Now;
        }
    }
}
