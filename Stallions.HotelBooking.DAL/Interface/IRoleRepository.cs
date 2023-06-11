using Stallions.HotelBooking.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Interface
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public Task<Role> GetByUserId(Guid id);
    }
}
