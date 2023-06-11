using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Stallions.HotelBooking.BLL.Interface
{
    /// <summary>
    /// Crud services interface.
    /// </summary>
    /// <typeparam name="T">Generic Parameter.</typeparam>
    public interface ICrudService<T>
    {
        /// <summary>
        /// Method declration of ICrudService to add the Object.
        /// </summary>
        /// <param name="entity">General object to be add.</param>
        /// <returns>General object after adding.</returns>
        public Task<T> Add(T entity);

        /// <summary>
        /// For adding list.
        /// </summary>
        /// <param name="entities">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Add(IEnumerable<T> entities);

        /// <summary>
        /// For adding list.
        /// </summary>
        /// <param name="entities">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Delete(IEnumerable<T> entities);

        /// <summary>
        /// Method declration of ICrudService to update the Object.
        /// </summary>
        /// <param name="entity">General object to be update.</param>
        /// <returns>General object after updating.</returns>
        public Task<T> Update(T entity);

        /// <summary>
        /// For updating list.
        /// </summary>
        /// <param name="entities">is an entity model.</param>
        /// <returns>Returns result.</returns>
        public Task Update(IEnumerable<T> entities);

        /// <summary>
        /// Method declration of ICrudService to get the Object.
        /// </summary>
        /// <param name="entity">General object to be get.</param>
        /// <returns>General object after getting.</returns>
        public Task<IEnumerable<T>> Get();

        public Task<T> GetSingle(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Method declration of ICrudService to delete the Object.
        /// </summary>
        /// <param name="entity">General object to be delete.</param>
        /// <returns>General object after deleting.</returns>
        public Task<bool> Delete(T entity);
    }
}
