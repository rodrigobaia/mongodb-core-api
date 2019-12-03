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
    /// Auditoria
    /// </summary>
    [Route("{application}/api/V1/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private readonly IAuditoriaBusiness _auditoriaBusiness;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="auditoriaBusiness"></param>
        /// <param name="mapper"></param>
        public AuditoriaController(IAuditoriaBusiness auditoriaBusiness,
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
        [Route("Insert")]
        public async Task<IActionResult> InsertAsync(AuditoriaRequestVM auditoriaRequestVM)
        {
            try
            {
                string nameApplication = this.ControllerContext.RouteData.Values["application"].ToString();

                var audity = _mapper.Map<AuditoriaRequestVM, AuditoriaInsertDTO>(auditoriaRequestVM);

                _auditoriaBusiness.DatabaseName = nameApplication;
                var results = await _auditoriaBusiness.InsertAsync(audity);

                var returnResponseVM = new ReturnResponseVM<AuditoriaInsertDTO>
                {
                    Code = 1,
                    Message = "Auditoria registrado com sucesso.",
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
        [Route("Filter")]
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

                var returnResponseVM = new ReturnResponseVM<IEnumerable<AuditoriaGetDTO>>
                {
                    Code = 1,
                    Message = "Filtro executado com sucesso.",
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