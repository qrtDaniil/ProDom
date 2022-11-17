using Microsoft.EntityFrameworkCore;

namespace ProDom.ApiServer.Models
{
    public class ApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Role> Roles { get; set; }


        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /*
        Address address11 = new Address(1, "150014", "Ярославль", "проспект Толбухина", "62", 4, 34);
        Address address12 = new Address(2, "150014", "Ярославль", "проспект Толбухина", "62", 4, 35);
        Address address13 = new Address(3, "150014", "Ярославль", "проспект Толбухина", "62", 1, 3);
        Address address21 = new Address(4, "150014", "Ярославль", "проспект Толбухина", "64", 1, 2);
        Address address22 = new Address(5, "150014", "Ярославль", "проспект Толбухина", "64", 2, 18);
        Address address23 = new Address(6, "150014", "Ярославль", "проспект Толбухина", "64", 3, 31);
        Address address31 = new Address(7, "150014", "Ярославль", "улица Богдановича", "6", 2, 18);
        Address address32 = new Address(8, "150014", "Ярославль", "улица Богдановича", "6", 2, 21);
        */
    }
}
