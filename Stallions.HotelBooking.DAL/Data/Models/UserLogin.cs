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
    [Table("UserLogin")]
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public override string LoginProvider { get; set; }

        public override string ProviderKey { get; set; }

        public override string ProviderDisplayName { get; set; }

        [Key]
        public override Guid UserId { get; set; }
    }
}
