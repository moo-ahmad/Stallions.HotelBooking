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
    [Table("UserToken")]
    public class UserToken : IdentityUserToken<Guid>
    {
        public override string LoginProvider { get; set; }

        public override string Name { get; set; }

        [Key]
        public override Guid UserId { get; set; }

        public override string Value { get; set; }
    }
}
