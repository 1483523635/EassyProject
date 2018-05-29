using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Datas;
using Web.Domains;
using Web.Events;
using Web.Storages;

namespace Web.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : AggrationRoot,new()
    {
        private readonly RepositoryDatabase _database;
   
        public Repository(RepositoryDatabase database)
        {
            _database = database;
        }
     
        public void Create(TEntity entity)
        {
            ArgumentNullCheck(entity);
            _database.Set<TEntity>().Add(entity);
            _database.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            ArgumentNullCheck(entity);
            _database.Remove(entity);
            _database.SaveChanges();
        }

        public TEntity GetByKey(long key)
        {
            return _database.Set<TEntity>().SingleOrDefault(entity => entity.Key.Equals(key));
        }

        public IEnumerable<TEntity> GetList()
        {
            return _database.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression)
        {
            return _database.Set<TEntity>().Where(expression).ToList();
        }

     
        public void SaveChanges()
        {
            _database.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var entity_db = GetByKey(entity.Key);
            if (entity_db == null)
            {
                throw new Exception($"the entity Key :{entity.Key}  not  in the  database");
            }
            _database.Set<TEntity>().Update(entity);
            _database.SaveChanges();
        }
        #region helpers

        private void ArgumentNullCheck(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
        }

        #endregion
    }
}
