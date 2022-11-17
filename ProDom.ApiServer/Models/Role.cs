using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleCode { get; set; }

        public string Name { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Role(int id, string roleCode, string name, DateTime updatedAt, DateTime createdAt)
        {
            Id = id;
            RoleCode = roleCode;
            Name = name;
            UpdatedAt = DateTime.Now;
            CreatedAt = DateTime.Now;
        }
    }
}
