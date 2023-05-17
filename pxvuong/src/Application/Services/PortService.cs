using AutoMapper;
using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class PortService : IPortService
{
    private readonly IRepositoryFactory _repositoryFactory;
    private readonly IMapper _mapper;

    public PortService(
        IRepositoryFactory repositoryFactory,
        IMapper mapper
        )
    {
        _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(repositoryFactory));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }


    Task<IEnumerable<Port>> IPortService.GetPorts()
    {
        return Task.FromResult(_repositoryFactory.GetRepository<Port>().Find(x => true));
    }
}
