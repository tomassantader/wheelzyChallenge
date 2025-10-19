using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Application.Services.FilesService;
using wheelzyChallenge.Application.Services.orderService;
using wheelzyChallenge.Application.Services.QuoteService;
using wheelzyChallenge.Infrastructure.DependeciesInjection;
using wheelzyChallenge.Infrastructure.Repositories;

namespace wheelzyChallenge.Application.DependenciesInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IFileService, FilesService>();
            serviceCollection.AddScoped<IQuoteService, QuoteService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            InfrastructureServiceCollectionExtensions.AddInfrastructure(serviceCollection, configuration);
            return serviceCollection;
        }
    }
}
