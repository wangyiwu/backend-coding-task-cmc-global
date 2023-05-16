using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private List<TEntity> _entities;

    public Repository()
    {
        this._entities = new List<TEntity>();
    }

    public List<TEntity> Entities {

        get { return _entities; }
        set { _entities = value; }
    }


    List<TEntity> IRepository<TEntity>.Entities
    {
        get { return _entities; }
        set { _entities = value; }
    }


    void IRepository<TEntity>.Delete(Func<TEntity, bool> predict)
    {
        TEntity entity = _entities.Where(predict).SingleOrDefault();
        if(entity != null)
        {
            _entities.Remove(entity);
        }
    }


    IEnumerable<TEntity> IRepository<TEntity>.Find(Func<TEntity, bool> expression)
    {
        IEnumerable<TEntity> items = _entities.Where(expression);
        return items;
    }


    TEntity IRepository<TEntity>.Insert(TEntity entity)
    {
        _entities.Add(entity);
        return entity;
    }


    TEntity IRepository<TEntity>.Update(TEntity entity, Func<TEntity, bool> predict)
    {
        int index = _entities.IndexOf(entity);
        if(index > -1)
        {
            _entities[index] = entity;  
        }
        return entity;
    }
}
