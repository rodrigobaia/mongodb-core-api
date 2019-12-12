using Log4net.Business;
using Log4net.Business.Interfaces;
using Log4net.Infra.Repository;
using Log4net.Infra.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Log4net.Infra.Crosscutting.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RepositoryRegister(services);
            BusinessRegister(services);
        }

        private static void BusinessRegister(IServiceCollection services)
        {

            services.AddScoped(typeof(IBusinessBase), typeof(BusinessBase));
            services.AddScoped(typeof(IAuditBusiness), typeof(AuditBusiness));

        }

        private static void RepositoryRegister(IServiceCollection services)
        {
            #region [ Repositories ]

            //Repositories

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IAuditRepository), typeof(AuditRepository));

            //var repositoryTypes = services..GetTypesToRegister(typeof(IRepositoryBase<>), new[] { Assembly.GetAssembly(typeof(RepositoryBase<>)) });

            //foreach (Type implementationType in repositoryTypes)
            //{
            //    Type serviceType =
            //        implementationType.GetInterfaces()
            //            .Single(i => !i.IsGenericType && i.Name.Contains(implementationType.Name));

            //    container.Register(serviceType, implementationType, Lifestyle.Scoped);

            //}

            #endregion [ Repositories ]
        }
    }
}
