using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository;

public class RepositoryFactory: IRepositoryFactory
{
    private ConcurrentDictionary<Type, object> repositories;

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        if (repositories == null)
        {
            repositories = new ConcurrentDictionary<Type, object>();
        }
        var type = typeof(TEntity);

        if (!repositories.ContainsKey(type))
        {
            var repository = new Repository<TEntity>();
            repositories[type] = repository;
        }

        return (IRepository<TEntity>)repositories[type];
    }
}

