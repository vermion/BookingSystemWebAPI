using System.Collections.Generic;

namespace BookingSystemWebAPI.Models.Entities
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<BookingType> BookingTypes { get; set; }
    }
}
