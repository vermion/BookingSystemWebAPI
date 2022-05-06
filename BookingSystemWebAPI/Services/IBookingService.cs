using BookingSystemWebAPI.Models.DTOS;
using BookingSystemWebAPI.Models.Entities;
using System;
using System.Collections.Generic;

namespace BookingSystemWebAPI.Services
{
    public interface IBookingService
    {
        ServiceResponse<bool> CreateBooking(BookingDTO bookingDTO);
    }
}
