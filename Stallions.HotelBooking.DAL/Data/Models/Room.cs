using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Data.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public int PricePerNight { get; set; }
        [ForeignKey("RoomType")]
        public Guid RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }  
        public List<RoomBooking> RoomBookings { get; set; }
    }
}
