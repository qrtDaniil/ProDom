using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class User
    {
        public int Id { get; set; }

        public int? PersonalAccountId { get; set; }
        public PersonalAccount? PersonalAccount { get; set; } = null!;

        public int? RoleId { get; set; }
        public Role? Role { get; set; } = null!;

        [MaxLength(90)]
        public string FullName { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public byte[]? ProfilePicture { get; set; }

        [MaxLength(40)]
        public string Password { get; set; }

        public int Points { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User(int id, int? personalAccountId, int? roleId, string fullName, string phoneNumber, byte[]? profilePicture, string password, int points, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            PersonalAccountId = personalAccountId;
            RoleId = roleId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            ProfilePicture = profilePicture;
            Password = password;
            Points = points;
            UpdatedAt = DateTime.Now;
            CreatedAt = DateTime.Now;
        }
    }
}
