using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Domains;

namespace Web.Infrastructure
{
    public interface IRepository<TEntity> where TEntity :AggrationRoot
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        TEntity GetByKey(long key);
        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression);
        void SaveChanges();
        void Delete(TEntity entity);
        //void Save(AggrationRoot aggrationRoot);
    }
}
