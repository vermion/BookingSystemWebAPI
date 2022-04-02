using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingSystemWebAPI.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}