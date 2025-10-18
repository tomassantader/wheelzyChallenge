using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wheelzyChallenge.Infrastructure.Repositories;

namespace wheelzyChallenge.Infrastructure.DependeciesInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection iServiceCollection, IConfiguration configuration)
        {
            iServiceCollection.AddScoped<IQuoteRepository, QuoteRepository>();
            return iServiceCollection;
        }
    }
}
