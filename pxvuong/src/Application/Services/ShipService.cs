using Application.Models.Ship;
using AutoMapper;
using Domain.Entities;
using Domain.Repository;
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
        this._repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));  
        
    }

    public Task<Ship> CreateShip(CreateShipRequest request)
    {
        var mapped = _mapper.Map<Ship>( request ); 
        mapped.Id = Guid.NewGuid();
        var result = _repositoryFactory.GetRepository<Ship>().Insert( mapped );
        return Task.FromResult(result);
    }

    public Task<IEnumerable<Ship>> GetShips()
    {
        var result = _repositoryFactory.GetRepository<Ship>().Find(x => true);
        return Task.FromResult(result);
    }
}
