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
    [Table("User")]
    public class User : IdentityUser<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        public override string UserName { get; set; }

        public override string NormalizedUserName { get; set; }

        public override string Email { get; set; }

        public override string NormalizedEmail { get; set; }

        public override bool EmailConfirmed { get; set; }

        public string PrimaryEmail { get; set; }

        public override string PasswordHash { get; set; }

        public override string SecurityStamp { get; set; }

        public override string ConcurrencyStamp { get; set; }

        public override string PhoneNumber { get; set; }

        public override bool PhoneNumberConfirmed { get; set; }

        public override bool TwoFactorEnabled { get; set; }

        public override DateTimeOffset? LockoutEnd { get; set; }

        public override bool LockoutEnabled { get; set; }

        public Guid? ImageId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public string JobTitle { get; set; }

        public bool IsLocked { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public string Role { get; set; }
        public int ResetPasswordCount { get; set; }

        public DateTime CreatedTimeStamp { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedTimeStamp { get; set; } = DateTime.UtcNow;
    }
}
