using Log4net.Core;
using Log4net.Infra.Crosscutting;
using Log4net.Infra.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace Log4net.Infra.Repository
{
    public sealed class AuditRepository : RepositoryBase<Audit>, IAuditRepository
    {

        public AuditRepository(IOptions<MongoSettings> mongoSettings)
            : base(mongoSettings)
        {

        }


    }
}
