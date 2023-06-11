using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.DAL.Interface
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// For adding.
        /// </summary>
        /// <param name="entity">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Add(T entity);

        /// <summary>
        /// For adding list.
        /// </summary>
        /// <param name="entities">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Add(IEnumerable<T> entities);

        /// <summary>
        /// For Deleting list.
        /// </summary>
        /// <param name="entities">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Delete(IEnumerable<T> entities);


        /// <summary>
        /// For updating.
        /// </summary>
        /// <param name="entity">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Update(T entity);

        /// <summary>
        /// For updating list.
        /// </summary>
        /// <param name="entities">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Update(IEnumerable<T> entities);

        /// <summary>
        /// For getting.
        /// </summary>
        /// <returns>Returns result.</returns>
        public Task<IEnumerable<T>> Get();

        /// <summary>
        /// For getting single item.
        /// </summary>
        /// <param name="predicate">Param, check weather.</param>
        /// <returns>Returns result.</returns>
        public Task<T> GetSingle(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// For getting.
        /// </summary>
        /// <param name="predicate">Param, check weather.</param>
        /// <returns>Returns result.</returns>
        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// For deleting.
        /// </summary>
        /// <param name="entity">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Delete(T entity);
    }
}
