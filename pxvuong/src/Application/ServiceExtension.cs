using Application.Services;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection service)
    {
        service.AddScoped<IShipService, ShipService>();

        service.AddAutoMapper(typeof(ServiceExtension).Assembly);

        service.AddRepositoryFactory();
    }

}
