using Application.Models.Dto.Ship;
using Application.Models.RequestModel.Ship;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Ultis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;


public class ShipService : IShipService
{
    private readonly IRepositoryFactory _repositoryFactory;
    private readonly IMapper _mapper;

    public ShipService(
        IRepositoryFactory repositoryFactory,
        IMapper mapper
        )
    {
        _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    public Task<ClosestPortDto> ClosestPort(string name)
    {
        var ship = _repositoryFactory.GetRepository<Ship>().Find(x => x.Name == name).SingleOrDefault();

        if (ship != null)
        {
            var listPort = _repositoryFactory.GetRepository<Port>().Find(x => true).ToList();
            if (listPort.Any())
            {
                Port closestPort = listPort.First();
                double closestDistance = HaversineUltis.CalculateDistance(ship.Position.Latitude, ship.Position.Longitude, closestPort.Position.Latitude, closestPort.Position.Longitude);

                if (listPort.Count() > 1)
                {
                    for (int i = 1; i < listPort.Count(); i++)
                    {
                        var currentPort = listPort[i];

                        double distance = HaversineUltis.CalculateDistance(ship.Position.Latitude, ship.Position.Longitude, currentPort.Position.Latitude, currentPort.Position.Longitude);

                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            closestPort = currentPort;
                        }
                    }
                }

                double estimatedArrivalTime = closestDistance / ship.Velocity; // Assuming ship's velocity is in kilometers per hour


                return Task.FromResult(
                    new ClosestPortDto()
                    {
                        Name = closestPort.Name,
                        ArrivalTime = estimatedArrivalTime,
                        Position = closestPort.Position,
                        Distance = closestDistance
                    }
               );
            }
        }
        return null;
    }

    public Task<Ship> CreateShip(CreateShipRequest request)
    {
        var mapped = _mapper.Map<Ship>(request);
        mapped.Id = Guid.NewGuid();

        var result = _repositoryFactory.GetRepository<Ship>().Insert(mapped);

        return Task.FromResult(result);
    }

    public Task<IEnumerable<Ship>> GetShips()
    {
        var result = _repositoryFactory.GetRepository<Ship>().Find(x => true);
        return Task.FromResult(result);
    }

    public Task<Ship> UpdateVelocity(string id, UpdateVelocityRequest request)
    {
        var ship = _repositoryFactory.GetRepository<Ship>().Find(x => x.Id == Guid.Parse(id)).SingleOrDefault();
        ship.Velocity = request.Velocity;
        _repositoryFactory.GetRepository<Ship>().Update(ship, x => x.Id == Guid.Parse(id));
        return Task.FromResult(ship);
    }


}
