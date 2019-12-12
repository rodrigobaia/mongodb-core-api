using AutoMapper;
using Log4net.Business.Interfaces;
using Log4net.Core;
using Log4net.DTO;
using Log4net.Infra.Repository.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log4net.Business
{
    public class AuditBusiness : BusinessBase, IAuditBusiness
    {
        private readonly IMapper _mapper;
        private readonly IAuditRepository _auditoriaRepository;

        public AuditBusiness(IMapper mapper,
                                IAuditRepository auditoriaRepository)
        {
            _mapper = mapper;
            _auditoriaRepository = auditoriaRepository;
        }

        public async Task<long> DeleteAsync(string id)
        {
            _auditoriaRepository.DatabaseName = DatabaseName;

            var results = await _auditoriaRepository.DeleteAsync(x => x.Id == ObjectId.Parse(id));

            return results;
        }

        public async Task<long> DeleteAsync(AuditGetDTO auditoriaGetDTO)
        {
            _auditoriaRepository.DatabaseName = DatabaseName;
            var results = await _auditoriaRepository.DeleteAsync(x => x.Id == ObjectId.Parse(auditoriaGetDTO.Id));

            return results;
        }

        public async Task<AuditGetDTO> GetByIdAsync(string id)
        {
            _auditoriaRepository.DatabaseName = DatabaseName;
            var audity = await _auditoriaRepository.GetByAsync(ObjectId.Parse(id));

            if (audity == null)
            {
                return null;
            }

            var auditoriaGetDTO = _mapper.Map<AuditGetDTO>(audity);
            return auditoriaGetDTO;
        }

        public async Task<long> InsertAsync(AuditInsertDTO auditoriaInsertDTO)
        {
            var auditoria = _mapper.Map<Audit>(auditoriaInsertDTO);
            _auditoriaRepository.DatabaseName = DatabaseName;
            var results = await _auditoriaRepository.InsertAsync(auditoria);

            auditoriaInsertDTO = _mapper.Map<Audit, AuditInsertDTO>(auditoria);
            auditoriaInsertDTO.Id = auditoria.Id.ToString();
            return results;
        }

        /// <summary>
        /// Period by List
        /// </summary>
        /// <param name="initDate">Begin date</param>
        /// <param name="endDate">Finish date</param>
        /// <param name="iniTime">Begin Time</param>
        /// <param name="endTime">Time finish</param>
        /// <returns>List Audity</returns>
        public async Task<IEnumerable<AuditGetDTO>> ListByPeriodAsync(DateTime initDate,
                                                                            DateTime endDate,
                                                                            TimeSpan iniTime,
                                                                            TimeSpan endTime)
        {
            var lstResults = new List<AuditGetDTO>();

            _auditoriaRepository.DatabaseName = DatabaseName;
            var intDateInt = Convert.ToInt32(string.Format(@"{0:yyyyMMdd}", initDate));
            var intDateEnd = Convert.ToInt32(string.Format(@"{0:yyyyMMdd}", endDate));
            var coutDate = (endDate - initDate).Days;
            var initDateCurrent = initDate;

            var filterTable = $"_Log_{intDateEnd}_{intDateInt}";
            await _auditoriaRepository.DropCollectionAsync(filterTable);

            if (coutDate >= 1)
            {

                do
                {
                    var tableName = $"_Log_{initDate:yyyyMMdd}";
                    _auditoriaRepository.NameTable = tableName;

                    var iniCreated = new DateTime(initDate.Year, initDate.Month, initDate.Day, iniTime.Hours, iniTime.Minutes, iniTime.Seconds);
                    var endCreated = new DateTime(initDate.Year, initDate.Month, initDate.Day, endTime.Hours, endTime.Minutes, endTime.Seconds);

                    var lst = await _auditoriaRepository.GetFilterAsync(x => x.CreatedIn >= iniCreated && x.CreatedIn <= endCreated);

                    if (lst.Count() == 0)
                    {
                        initDate = initDate.AddDays(1);
                        continue;
                    }

                    _auditoriaRepository.NameTable = filterTable;
                    await _auditoriaRepository.InsertAsync(lst.ToList());

                    initDate = initDate.AddDays(1);
                } while (initDate <= endDate);

            }

            var iniCreated1 = new DateTime(initDateCurrent.Year, initDateCurrent.Month, initDateCurrent.Day, iniTime.Hours, iniTime.Minutes, iniTime.Seconds);
            var endCreated1 = new DateTime(endDate.Year, endDate.Month, endDate.Day, endTime.Hours, endTime.Minutes, endTime.Seconds);

            _auditoriaRepository.NameTable = filterTable;
            var lst1 = await _auditoriaRepository.GetFilterAsync(x => x.CreatedIn >= iniCreated1 && x.CreatedIn <= endCreated1);

            lstResults = _mapper.Map<List<AuditGetDTO>>(lst1);
            await _auditoriaRepository.DropCollectionAsync(filterTable);

            return lstResults;
        }


        public async Task<AuditGetDTO> UpdateAsync(AuditUpdateDTO auditoriaUpdateDTO)
        {
            _auditoriaRepository.DatabaseName = DatabaseName;

            var audity = _mapper.Map<Audit>(auditoriaUpdateDTO);

            await _auditoriaRepository.UpdateAsync(audity);

            var auditoriaGetDTO = _mapper.Map<AuditGetDTO>(audity);

            return auditoriaGetDTO;
        }
    }
}
