using Stallions.HotelBooking.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets context property.
        /// </summary>
        public ApplicationDbContext Context { get; }

        /// <summary>
        /// Stores changes performed by a transaction
        /// </summary>
        public void Commit();
    }
}
