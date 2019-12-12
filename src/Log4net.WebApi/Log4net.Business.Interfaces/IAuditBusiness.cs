using Log4net.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Log4net.Business.Interfaces
{
    /// <summary>
    /// Business de Auditoria
    /// </summary>
    public interface IAuditBusiness : IBusinessBase
    {

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AuditGetDTO> GetByIdAsync(string id);

        /// <summary>
        /// Inserir Auditoria
        /// </summary>
        /// <param name="auditoriaInsertDTO"></param>
        /// <returns></returns>
        Task<long> InsertAsync(AuditInsertDTO auditoriaInsertDTO);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditoriaUpdateDTO"></param>
        /// <returns></returns>
        Task<AuditGetDTO> UpdateAsync(AuditUpdateDTO auditoriaUpdateDTO);

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
        Task<long> DeleteAsync(AuditGetDTO auditoriaGetDTO);

        /// <summary>
        /// Period by List
        /// </summary>
        /// <param name="initDate">Begin date</param>
        /// <param name="endDate">Finish date</param>
        /// <param name="iniTime">Begin Time</param>
        /// <param name="endTime">Time finish</param>
        /// <returns>List Audity</returns>
        Task<IEnumerable<AuditGetDTO>> ListByPeriodAsync(DateTime initDate, DateTime endDate, TimeSpan iniTime, TimeSpan endTime);


    }
}
