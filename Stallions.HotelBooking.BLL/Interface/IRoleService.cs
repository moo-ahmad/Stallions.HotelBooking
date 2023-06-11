using Stallions.HotelBooking.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.BLL.Interface
{
    public interface IRoleService : ICrudService<Role>
    {
        public Task<Role> GetById(Guid id);

        public Task<Role> GetByName(string name);

        public Task<Role> GetByUserId(Guid id);
    }
}
