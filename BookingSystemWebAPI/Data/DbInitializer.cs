using BookingSystemWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemWebAPI.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<User>().HasData(
                new
                {
                    Id = 1,
                    UserName = "tereng",
                    PasswordHash = new byte[2],
                    PasswordSalt = new byte[3]
                });

            modelBuilder.Entity<Facility>().HasData(
                new
                {
                    Id = 1,
                    Name = "HairÄrVi",
                    Address = "Storgatan 1"
                });

            modelBuilder.Entity<BookingType>().HasData(
                new
                {
                    Id = 1,
                    Name = "Klippning kort hår",
                    Price = 100,
                    TimeInMinutes = 30,
                    FacilityId = 1
                });

            modelBuilder.Entity<BookingType>().HasData(
                new
                {
                    Id = 2,
                    Name = "Klippning långt hår",
                    Price = 200,
                    TimeInMinutes = 60,
                    FacilityId = 1
                });
        }
    }
}
