using AutoMapper;

namespace Log4net.Infra.Crosscutting.Mappings
{
    /// <summary>
    /// Configuração de Mapeamento com Automapper
    /// </summary>
    public static class AutoMappingConfig
    {
        /// <summary>
        /// Registrar mapeamento
        /// </summary>
        public static IMapper RegisterMappings()
        {
            IMapper mapper = null;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CoreToDataContractObjectProfile>();
                cfg.AddProfile<DataContractObjectToCoreProfile>();
                cfg.AddProfile<DataContractObjectToViewModel>();
                cfg.AddProfile<ViewModelToDataContractObject>();
            });

            config.AssertConfigurationIsValid();
            mapper = config.CreateMapper();

            return mapper;
        }
    }
}
