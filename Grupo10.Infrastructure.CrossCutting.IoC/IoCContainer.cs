using Grupo10.Domain.Contracts.Repositories;
using Grupo10.Domain.Contracts.Services;
using Grupo10.Infrastructure.Data.Repositories;
using Grupo10.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupo10.Domain.Core.Contracts;
using Grupo10.Infrastructure.Data.UnitOfWork;

namespace Grupo10.Infrastructure.CrossCutting.IoC
{
    public enum IoCMode { Production, Testing }
    public class IoCContainer {
        private static IServiceProvider services;
        private static IServiceCollection serviceCollection = new ServiceCollection();
        public static IoCMode Modo { get; set; } = IoCMode.Production;
        private static IServiceProvider Services {
            get {
                if (services == null) {
                    services = Modo == IoCMode.Production ? ConfigProduction() : ConfigTesting();
                }
                return services;
            }
        }
        private static IServiceProvider ConfigProduction() {
            if (IoCMode.Production == Modo)
                serviceCollection
                    .AddSingleton<IExpedienteRepository, ExpedienteRepository>();
            else {
                serviceCollection
                    .AddSingleton<IExpedienteRepository, ExpedienteRepositoryMock>();
                    
            }
            serviceCollection
                .AddTransient<IUnitOfWork, DBContext>()
                .AddTransient<IExpedienteDomainService, ExpedienteDomainService>();
            return serviceCollection.BuildServiceProvider();
        }
        private static IServiceProvider ConfigTesting() {
            serviceCollection
                .AddSingleton<IExpedienteRepository, ExpedienteRepositoryMock>()
                .AddTransient<IUnitOfWork, DBContext>()
                .AddTransient<IExpedienteDomainService, ExpedienteDomainService>();
            return serviceCollection.BuildServiceProvider();
        }
        public static TService Resuelve<TService>() { return Services.GetService<TService>(); }
        public static IEnumerable<TService> GetServices<TService>() { return Services.GetServices<TService>(); }
    }
}
