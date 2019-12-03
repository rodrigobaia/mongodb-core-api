using Log4net.Core;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Log4net.Infra.Repository.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IRepositoryBase<TModel> where TModel : EntityBase
    {
        /// <summary>
        /// Name database
        /// </summary>
        string DatabaseName { get; set; }

        /// <summary>
        /// Table name
        /// </summary>
        string NameTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<long> InsertAsync(TModel entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<long> InsertAsync(IEnumerable<TModel> entities);

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetByAsync(ObjectId id);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<long> DeleteAsync(Expression<Func<TModel, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TModel>> GetFilterAsync(Expression<Func<TModel, bool>> predicate);

        /// <summary>
        /// Update register
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<long> UpdateAsync(TModel entity);

        /// <summary>
        /// Drop collection
        /// </summary>
        /// <param name="nameTable"></param>
        Task DropCollectionAsync(string nameTable);

    }
}
