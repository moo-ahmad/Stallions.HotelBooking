using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Stallions.HotelBooking.DAL.Data.Models
{
    [Table("Role")]
    public class Role : IdentityRole<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        public override string Name { get; set; }

        public override string NormalizedName { get; set; }

        public override string ConcurrencyStamp { get; set; }
    }
}
