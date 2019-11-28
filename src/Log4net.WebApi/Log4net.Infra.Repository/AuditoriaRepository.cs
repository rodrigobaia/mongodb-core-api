using Log4net.Core;
using Log4net.Infra.Repository.Interfaces;
using Log4net.ValueObject;
using Microsoft.Extensions.Options;
using System;

namespace Log4net.Infra.Repository
{
    public sealed class AuditoriaRepository : RepositoryBase<Auditoria>, IAuditoriaRepository
    {

        public AuditoriaRepository(IOptions<MongoSettings> mongoSettings)
            : base(mongoSettings)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditoria"></param>
        /// <param name="nameApplication"></param>
        /// <returns></returns>
        public Auditoria Insert(Auditoria auditoria)
        {
            
            
            throw new NotImplementedException();
        }
    }
}
