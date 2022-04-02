using System.Collections.Generic;

namespace BookingSystemWebAPI.Models.Entities
{
    public class BookingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeInMinutes { get; set; }
        public int Price { get; set; }

        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
