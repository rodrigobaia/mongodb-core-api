using AutoMapper;
using Log4net.Business.Interfaces;
using Log4net.DTO;
using Log4net.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Log4net.WebApi.Controllers
{
    /// <summary>
    /// Audit
    /// </summary>
    [Route("{application}/api/V1/audit")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditBusiness _auditoriaBusiness;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="auditoriaBusiness"></param>
        /// <param name="mapper"></param>
        public AuditController(IAuditBusiness auditoriaBusiness,
                                    IMapper mapper)
        {
            _mapper = mapper;
            _auditoriaBusiness = auditoriaBusiness;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditoriaRequestVM"></param>
        /// <returns></returns>
        [HttpPost()]
        [Route("insert")]
        public async Task<IActionResult> InsertAsync(AuditoriaRequestVM auditoriaRequestVM)
        {
            try
            {
                string nameApplication = this.ControllerContext.RouteData.Values["application"].ToString();

                var audity = _mapper.Map<AuditoriaRequestVM, AuditInsertDTO>(auditoriaRequestVM);

                _auditoriaBusiness.DatabaseName = nameApplication;
                var results = await _auditoriaBusiness.InsertAsync(audity);

                var returnResponseVM = new ReturnResponseVM<AuditInsertDTO>
                {
                    Code = 1,
                    Message = "Audit successfully registered.",
                    Content = audity
                };

                return new ObjectResult(returnResponseVM);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }

        /// <summary>
        /// FIlter
        /// </summary>
        /// <param name="audtiyFIlterVM"></param>
        /// <returns></returns>
        [HttpPut()]
        [Route("filter")]
        public async Task<IActionResult> FilterAsync(AudtiyFIlterVM audtiyFIlterVM)
        {
            try
            {
                string nameApplication = this.ControllerContext.RouteData.Values["application"].ToString();

                var initTime = Convert.ToDateTime(audtiyFIlterVM.InitTime);
                var endTime = Convert.ToDateTime(audtiyFIlterVM.EndTime);

                _auditoriaBusiness.DatabaseName = nameApplication;
                var audits = await _auditoriaBusiness.ListByPeriodAsync(audtiyFIlterVM.InitDate,
                                                                        audtiyFIlterVM.EndDate,
                                                                        new TimeSpan(initTime.Hour, initTime.Minute, initTime.Second),
                                                                        new TimeSpan(endTime.Hour, endTime.Minute, endTime.Second));

                var returnResponseVM = new ReturnResponseVM<IEnumerable<AuditGetDTO>>
                {
                    Code = 1,
                    Message = "Filter successfully executed.",
                    Content = audits
                };

                return new ObjectResult(returnResponseVM);
            }
            catch (Exception ex)
            {

                return new ObjectResult(ex);
            }
        }
    }
}