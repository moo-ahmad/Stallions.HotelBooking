using Microsoft.Extensions.Logging;
using Stallions.HotelBooking.DAL.Data;
using Stallions.HotelBooking.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;
        /// <summary>
        /// Database context of the application
        /// </summary>
        public ApplicationDbContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">object of ApplicationDbContext.</param>
        /// <param name="logger">object of ILogger.</param>
        public UnitOfWork(ApplicationDbContext context, ILogger<UnitOfWork> logger)
        {
            Context = context;
            _logger = logger;
        }

        /// <summary>
        /// Commit save changes.
        /// </summary>
        public void Commit()
        {
            try
            {
                _logger.LogInformation("Commit save changes");
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
