using Microsoft.Extensions.Logging;
using Stallions.HotelBooking.DAL.Data.Models;
using Stallions.HotelBooking.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleRepository(IUnitOfWork unitOfWork, ILogger<RoleRepository> logger)
            : base(unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Role> GetByUserId(Guid id)
        {
            try
            {
                Role role = new Role();
                role = (from ur in _unitOfWork.Context.UserRoles
                        join r in _unitOfWork.Context.Roles on ur.RoleId equals r.Id
                        where ur.UserId == id
                        select new Role
                        {
                            Id = r.Id,
                            Name = r.Name
                        }).FirstOrDefault();
                return await Task.FromResult(role);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
