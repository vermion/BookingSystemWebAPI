using BookingSystemWebAPI.Models.Entities;
using System.Collections.Generic;

namespace BookingSystemWebAPI
{
    public class ServiceResponse<T>
    {

        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string ErrorMessage { get; set; } = null;
    }
}
