using AutoMapper;
using Log4net.DTO;
using Log4net.DTO.ViewModels;

namespace Log4net.Infra.Crosscutting.Mappings
{
    public sealed class ViewModelToDataContractObject : Profile
    {
        public ViewModelToDataContractObject()
        {
            AuditoriaCreateMap();

        }

        private void AuditoriaCreateMap()
        {
            CreateMap<AuditoriaRequestVM, AuditInsertDTO>()
                .ForMember(des => des.Id, opt => opt.Ignore())
                .ForMember(des => des.CreatedIn, opt => opt.Ignore());
        }
    }
}
