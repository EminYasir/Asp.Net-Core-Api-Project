﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.BookingDto
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Ad Alanı Gereklidir.")]
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string AdultCount { get; set; }
        public string ChildCount { get; set; }
        public string RoomCount { get; set; }
        public string SpecialRequest { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
