using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stallions.HotelBooking.DAL.Data.Models;
using Stallions.HotelBooking.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>(entity => { entity.ToTable("User"); });
            builder.Entity<UserClaim>(entity => { entity.ToTable("UserClaim"); });
            builder.Entity<UserLogin>(entity => { entity.ToTable("UserLogin"); });
            builder.Entity<UserToken>(entity => { entity.ToTable("UserToken"); });
            builder.Entity<UserRole>(entity => { entity.ToTable("UserRole"); });
            builder.Entity<Role>(entity => { entity.ToTable("Role"); });
            builder.Entity<RoleClaim>(entity => { entity.ToTable("RoleClaim"); });

            builder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = RoleEnums.Admin.ToString(), NormalizedName = RoleEnums.Admin.ToString().ToLower(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<Role>().HasData(new Role { Id = Guid.NewGuid(), Name = RoleEnums.Customer.ToString(), NormalizedName = RoleEnums.Customer.ToString().ToLower(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<BookingStatus>().HasData(new BookingStatus { Id = Guid.NewGuid(), Name = BookingStatusEnum.Pending.ToString() });
            builder.Entity<BookingStatus>().HasData(new BookingStatus { Id = Guid.NewGuid(), Name = BookingStatusEnum.Accepted.ToString() });
            builder.Entity<BookingStatus>().HasData(new BookingStatus { Id = Guid.NewGuid(), Name = BookingStatusEnum.Rejected.ToString() });
            builder.Entity<RoomType>().HasData(new RoomType { Id = Guid.NewGuid(), Name = RoomTypeEnum.Single.ToString() });
            builder.Entity<RoomType>().HasData(new RoomType { Id = Guid.NewGuid(), Name = RoomTypeEnum.Double.ToString() });
        }

        public new DbSet<Role> Roles { get; set; }
        public new DbSet<UserRole> UserRoles { get; set; }
        public new DbSet<User> Users { get; set; }
        public new DbSet<RoleClaim> RoleClaims { get; set; }
        public new DbSet<UserClaim> UserClaims { get; set; }
        public new DbSet<UserLogin> UserLogins { get; set; }
        public new DbSet<UserToken> UserTokens { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; } 
        public DbSet<BookingStatus> BookingStatuses { get; set; } 
        public DbSet<Room> Rooms { get; set; } 
        public DbSet<RoomType> RoomTypes { get; set; }
    }
}
