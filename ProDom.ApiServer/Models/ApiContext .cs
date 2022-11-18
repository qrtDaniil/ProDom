using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace ProDom.ApiServer.Models
{
    public class ApiContext : DbContext
    {
        // all models
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<Address> Addressses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Appeal> Appeals { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // DB seeding
            modelBuilder.Entity<Address>().HasData(
                new Address(-1, "150014", "Ярославль", "проспект Толбухина", "62", 4, 52), 
                new Address(-2, "150014", "Ярославль", "проспект Толбухина", "62", 4, 56),
                new Address(-3, "150014", "Ярославль", "проспект Толбухина", "62", 4, 48),
                new Address(-4, "150014", "Ярославль", "проспект Толбухина", "62", 4, 60),
                new Address(-5, "150014", "Ярославль", "проспект Толбухина", "62", 2, 18),
                new Address(-6, "150014", "Ярославль", "проспект Толбухина", "62", 2, 74),
                new Address(-7, "150014", "Ярославль", "улица Богдановича", "6", 2, 18),
                new Address(-8, "150014", "Ярославль", "улица Богдановича", "6", 2, 21)
            );

            modelBuilder.Entity<PersonalAccount>().HasData(
                new PersonalAccount(-1, "23587283125", 0, -1),
                new PersonalAccount(-2, "23623623784", 1000, -2),
                new PersonalAccount(-3, "84584584584", 1000, -3),
                new PersonalAccount(-4, "27237237237", 4000, -4),
                new PersonalAccount(-5, "85498412727", 500, -5),
                new PersonalAccount(-6, "12639691588", 8500, -6),
                new PersonalAccount(-7, "01928407581", 500, -7),
                new PersonalAccount(-8, "83712968576", 0, -8)
            );

            modelBuilder.Entity<Role>().HasData(
                new Role(-1, null, "Староста дома"),
                new Role(-2, null, "Староста подъезда №2")
            );

            modelBuilder.Entity<User>().HasData(
                new User(-1, -1, null, "Баранов Кирилл Владимирович", "9126236336", null, "testpassword"),
                new User(-2, -2, null, "Чистяков Павел Русланович", "9126236336", null, "testpassword"),
                new User(-3, -3, null, "Константинов Максим Григорьевич", "9126236336", null, "testpassword"),
                new User(-4, -4, null, "Федоров Дмитрий Артёмович", "9126236336", null, "testpassword"),
                new User(-5, -5, -2, "Тихонова Анна Кирилловна", "9126236336", null, "testpassword"),
                new User(-6, -6, null, "Павлова Маргарита Данииловна", "9126236336", null, "testpassword"),
                new User(-7, -7, null, "Власов Даниил Русланович", "9126236336", null, "testpassword"),
                new User(-8, -8, null, "Костина Анастасия Николаевна", "9126236336", null, "testpassword"),
                new User(-9, -1, -1, "Баранова Мария Алексеевна", "9126236336", null, "testpassword"),
                new User(-10, -2, null, "Котов Ярослав Витальевич", "9126236336", null, "testpassword")
            );

            modelBuilder.Entity<Poll>().HasData(
                new Poll(-1, -9, "Установавливать ли видеокамеры, пожарные и газовые датчики", "УК предлагает установаить датчики видеокамеры во дворе и подъезде, а также датчики задымления и газовые датчики, с возможностью прямого доступа к ним через приложение умного дома."),
                new Poll(-2, -9, "Выбор цвета покраски стен в подъездах", "Скоро у нас в доме по плану капитального ремонта будут красить стены в подъездах. Надо определится с цветом чтобы всем угодило.")
            );

            modelBuilder.Entity<PollOption>().HasData(
                new PollOption(-1, -1, "Да", 0),
                new PollOption(-2, -1, "Скорее да", 0),
                new PollOption(-3, -1, "Скорее нет", 0),
                new PollOption(-4, -1, "Нет", 0),
                new PollOption(-5, -2, "Серый", 0),
                new PollOption(-6, -2, "Синий", 0),
                new PollOption(-7, -2, "Белый", 0),
                new PollOption(-8, -2, "Пурпурный", 0),
                new PollOption(-9, -2, "Красный", 0),
                new PollOption(-10, -2, "Лучше по светлее", 0),
                new PollOption(-11, -2, "Лучше по темнее", 0)
            );
        }

        public override int SaveChanges()
        {
            // override to provide changes of updatedAt and createdAt collumns
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
