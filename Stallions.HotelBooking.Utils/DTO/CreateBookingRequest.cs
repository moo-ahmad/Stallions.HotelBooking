using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.Utils.DTO
{
    public class CreateBookingRequest
    {
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set;}
        public string RoomType { get; set;}
        public int NumberOfGuests { get; set;}
        public string Name { get; set;}
        public string Email { get; set;}
        public int PhoneNumber { get; set;}
        public string SpecialRequests { get; set;} 
        public string PaymentInfo { get; set;}
        public bool TermsAndConditions { get; set;}
    }
}
