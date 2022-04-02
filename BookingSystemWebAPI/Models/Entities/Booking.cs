using System;

namespace BookingSystemWebAPI.Models.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int BookingTypeId { get; set; }

        public BookingType BookingType { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int FacilityId { get; set; }

        public Facility Facility { get; set; }
    }
}