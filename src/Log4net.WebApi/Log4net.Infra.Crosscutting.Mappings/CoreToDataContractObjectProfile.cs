using AutoMapper;
using Log4net.Core;
using Log4net.DTO;

namespace Log4net.Infra.Crosscutting.Mappings
{
    public sealed class CoreToDataContractObjectProfile : Profile
    {

        public CoreToDataContractObjectProfile()
        {
            AuditoriaCreateMap();

        }

        private void AuditoriaCreateMap()
        {
            CreateMap<Auditoria, AuditoriaInsertDTO>();

            CreateMap<Auditoria, AuditoriaGetDTO>();


        }
    }
}