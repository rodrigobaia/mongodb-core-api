using Log4net.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Log4net.Business.Interfaces
{
    /// <summary>
    /// Business de Auditoria
    /// </summary>
    public interface IAuditoriaBusiness : IBusinessBase
    {

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AuditoriaGetDTO> GetByIdAsync(string id);

        /// <summary>
        /// Inserir Auditoria
        /// </summary>
        /// <param name="auditoriaInsertDTO"></param>
        /// <returns></returns>
        Task<long> InsertAsync(AuditoriaInsertDTO auditoriaInsertDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditoriaUpdateDTO"></param>
        /// <returns></returns>
        Task<AuditoriaGetDTO> UpdateAsync(AuditoriaUpdateDTO auditoriaUpdateDTO);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">Id register</param>
        /// <returns></returns>
        Task<long> DeleteAsync(string id);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="auditoriaGetDTO">Object Auditoria</param>
        /// <returns></returns>
        Task<long> DeleteAsync(AuditoriaGetDTO auditoriaGetDTO);

        /// <summary>
        /// Period by List
        /// </summary>
        /// <param name="initDate">Begin date</param>
        /// <param name="endDate">Finish date</param>
        /// <param name="iniTime">Begin Time</param>
        /// <param name="endTime">Time finish</param>
        /// <returns>List Audity</returns>
        Task<IEnumerable<AuditoriaGetDTO>> ListByPeriodAsync(DateTime initDate, DateTime endDate, TimeSpan iniTime, TimeSpan endTime);


    }
}
