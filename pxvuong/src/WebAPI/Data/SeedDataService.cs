using Domain.Entities;
using Domain.Repositories;
using Domain.Repository;

namespace WebAPI.Data;

public class SeedDataService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public SeedDataService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var repositoryFactory = scope.ServiceProvider.GetRequiredService<IRepositoryFactory>();

            var portRepository = repositoryFactory.GetRepository<Port>();
            var shipRepository = repositoryFactory.GetRepository<Ship>();

            if(!portRepository.Entities.Any())
            {
                var portSeed = PortSeedData.SeedPortData();
                portRepository.Entities = portSeed;
            }

            if (!shipRepository.Entities.Any())
            {
                var portSeed = PortSeedData.SeedShipData();
                shipRepository.Entities = portSeed;
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
