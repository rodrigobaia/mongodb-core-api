using AutoMapper;
using Log4net.Core;
using Log4net.Infra.Repository.Interfaces;
using Log4net.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IAuditoriaRepository _auditoriaRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="auditoriaRepository"></param>
        /// <param name="mapper"></param>
        public AuditoriaController(IAuditoriaRepository auditoriaRepository,
                                    IMapper mapper)
        {
            _mapper = mapper;
            _auditoriaRepository = auditoriaRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditoriaVM"></param>
        /// <returns></returns>
        [HttpPost(Name = "Insert")]
        public async Task<IActionResult> InsertAsync(AuditoriaVM auditoriaVM)
        {
            try
            {
                string nameApplication = this.ControllerContext.RouteData.Values["application"].ToString();

                var auditoria = _mapper.Map<AuditoriaVM, Auditoria>(auditoriaVM);

                _auditoriaRepository.DatabaseName = nameApplication;
                var results = await _auditoriaRepository.InsertAsync(auditoria);

                return new ObjectResult(auditoria);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}