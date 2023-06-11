using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Data.Models
{
    [Table("RoomBooking")]
    public class RoomBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid CustomerId { get; set; }
        public User User { get; set; }
        [ForeignKey("Room")]
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set;}
        [ForeignKey("BookingStatus")]
        public Guid BookingStatusId { get; set; }
        public BookingStatus BookingStatus { get; set; }

    }
}
