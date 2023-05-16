using Application.Services;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace Application;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection service)
    {
        //In practive we 
        service.AddScoped<IShipService, ShipService>();
        service.AddAutoMapper(typeof(ServiceExtension).Assembly);

        //Here I use Singleton for lifecycle IRepositoryFactory to ensure Data after each API Request is saved, 
        //in fact, when the application uses Databases, we use Scope
        service.AddSingleton<IRepositoryFactory, RepositoryFactory>();
    }

}
