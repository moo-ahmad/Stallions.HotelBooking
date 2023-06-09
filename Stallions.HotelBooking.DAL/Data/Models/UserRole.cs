using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Data.Models
{
    [Table("UserRole")]
    public class UserRole : IdentityUserRole<Guid>
    {
        [Key]
        public override Guid UserId { get; set; }

        [Key]
        public override Guid RoleId { get; set; }
    }
}
