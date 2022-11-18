using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class Role : BaseModel
    {
        public int Id { get; set; }

        public string? RoleCode { get; set; }

        public string Name { get; set; }

        public Role(int id, string? roleCode, string name)
        {
            Id = id;
            RoleCode = roleCode;
            Name = name;
        }
    }
}
