using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository;

public interface IRepository<TEntity>
{
    public List<TEntity> Entities { get; set; }

    public TEntity Insert(TEntity entity);
    public TEntity Update(TEntity entity, Func<TEntity, bool> predict);
    public void Delete(Func<TEntity, bool> predict);
    public IEnumerable<TEntity> Find(Func<TEntity, bool> expression);
}
