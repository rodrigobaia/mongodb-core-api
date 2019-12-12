using AutoMapper;
using Log4net.Core;
using Log4net.DTO;

namespace Log4net.Infra.Crosscutting.Mappings
{
    public sealed class DataContractObjectToCoreProfile : Profile
    {

        public DataContractObjectToCoreProfile()
        {
            AuditoriaCreateMap();
        }

        private void AuditoriaCreateMap()
        {
            CreateMap<AuditInsertDTO, Audit>()
                .ForMember(des => des.Id, opt => opt.Ignore());


            CreateMap<AuditUpdateDTO, Audit>()
                .ForMember(des => des.Id, opt => opt.Ignore());

        }
    }
}