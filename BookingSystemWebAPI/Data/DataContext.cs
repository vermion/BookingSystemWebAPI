using BookingSystemWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<BookingType> BookingTypes { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Facility>()
            //    .HasMany<Booking>(s => s.Bookings)
            //    .WithOne(s => s.Facility)
            //    .HasForeignKey(s => s.FacilityId)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne<User>(s => s.User)
                .WithMany(s => s.Bookings)
                .HasForeignKey(u => u.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne<Facility>(s => s.Facility)
                .WithMany()
                .HasForeignKey(u => u.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<User>()
            //    .HasOne<Booking>(s => s.Bookings)
            //    .WithOne(s => s.UserId)
            //    .HasForeignKey(u => u.)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingType>()
                .HasOne<Facility>(s => s.Facility)
                .WithMany(s => s.BookingTypes)
                .HasForeignKey(u => u.FacilityId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}