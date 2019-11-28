using Log4net.Core;
using System.Collections.Generic;
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
        /// Total fields
        /// </summary>
        /// <returns></returns>
        long CountFields();
    }
}
