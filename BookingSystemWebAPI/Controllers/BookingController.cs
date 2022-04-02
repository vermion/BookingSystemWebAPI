using BookingSystemWebAPI.Models.DTOS;
using BookingSystemWebAPI.Models.Entities;
using BookingSystemWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BookingSystemWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _bookingService;

        public BookingController(ILogger<BookingController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult Post(BookingDTO booking)
        {
            var result = _bookingService.CreateBooking(booking);

            return Ok();
        }


    }
}
