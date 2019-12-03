using Log4net.Core;
using Log4net.Infra.Crosscutting;
using Log4net.Infra.Repository.Interfaces;
using Microsoft.Extensions.Options;

namespace Log4net.Infra.Repository
{
    public sealed class AuditoriaRepository : RepositoryBase<Auditoria>, IAuditoriaRepository
    {

        public AuditoriaRepository(IOptions<MongoSettings> mongoSettings)
            : base(mongoSettings)
        {

        }


    }
}
