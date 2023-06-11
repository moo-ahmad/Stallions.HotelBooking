using Stallions.HotelBooking.BLL.Interface;
using Stallions.HotelBooking.DAL.Data.Models;
using Stallions.HotelBooking.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.BLL.Service
{
    public class UserRoleService : CrudService<UserRole>, IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
            : base(userRoleRepository, unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
