using BookingSystemWebAPI.Data;
using BookingSystemWebAPI.Models.DTOS;
using BookingSystemWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystemWebAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly DataContext _dataContext;

        public BookingService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public ServiceResponse<bool> CreateBooking(BookingDTO bookingDTO)
        {
            var booking = new Booking
            {
                BookingTypeId = bookingDTO.BookingTypeId,
                FacilityId = bookingDTO.FacilityId,
                UserId = bookingDTO.UserId,
                Date = System.DateTime.UtcNow
            };

            _dataContext.Add<Booking>(booking);
            _dataContext.SaveChanges();

            return new ServiceResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorMessage = null
            };
        }
    }
}