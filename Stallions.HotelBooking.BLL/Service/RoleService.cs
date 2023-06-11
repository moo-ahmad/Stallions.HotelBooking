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
    public class RoleService : CrudService<Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
            : base(roleRepository, unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public async new Task<IEnumerable<Role>> Get()
        {
            return await _roleRepository.Get();
        }

        public async Task<Role> GetById(Guid id)
        {
            return await _roleRepository.GetSingle(r => r.Id == id);
        }

        public async Task<Role> GetByName(string name)
        {
            return await _roleRepository.GetSingle(r => r.Name == name);
        }

        public async Task<Role> GetByUserId(Guid id)
        {
            return await _roleRepository.GetByUserId(id);
        }
    }
}
