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
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserRoleRepository> _logger;
        public UserRoleRepository(IUnitOfWork unitOfWork, ILogger<UserRoleRepository> logger)
            : base(unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
    }
}
