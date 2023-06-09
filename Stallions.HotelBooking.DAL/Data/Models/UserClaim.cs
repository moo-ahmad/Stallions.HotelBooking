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
    [Table("UserClaim")]
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public override int Id { get; set; }

        public override string ClaimType { get; set; }

        public override string ClaimValue { get; set; }

        [Key]
        public override Guid UserId { get; set; }
    }
}
