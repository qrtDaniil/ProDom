using System.ComponentModel.DataAnnotations;

namespace ProDom.ApiServer.Models
{
    public class Address
    {
        public int Id { get; set; }

        public PersonalAccount? PersonalAccount { get; set; }

        [MaxLength(40)]
        public string? Index { get; set; }

        [MaxLength(40)]
        public string? City { get; set; }

        [MaxLength(40)]
        public string? Street { get; set; }

        [MaxLength(10)]
        public string House { get; set; }

        public int Entrance { get; set; }

        public int Apartment { get; set; }

        public Address(int id, string? index, string? city, string? street, string house, int entrance, int apartment)
        {
            Id = id;
            Index = index;
            City = city;
            Street = street;
            House = house;
            Entrance = entrance;
            Apartment = apartment;
        }
    }
}
