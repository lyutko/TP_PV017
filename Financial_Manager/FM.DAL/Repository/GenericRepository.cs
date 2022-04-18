using FM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.DAL.Repository
{
    public class GenericRepository<T> : IDataGenericRepository<T> where T : class
    {
        private DbContext _dbContext;
        private DbSet<T> _set;
        public GenericRepository(DbContext _dbContext)
        {
            this._dbContext = _dbContext;
            _set = _dbContext.Set<T>();
        }

        public void Create(T newEntity)
        {
            _set.Add(newEntity);

            _dbContext.SaveChanges();
        }
     
        public void Delete(T newEntity)
        {
            _dbContext.Entry(newEntity).State = EntityState.Deleted;

           

            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            T realEntity = Get(id);
            if (realEntity != null)
            {
                _set.Remove(realEntity);
                _dbContext.SaveChanges();
            }
        }
        public void SaveChange(T Entity)
        {
            _dbContext.Entry(Entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public T Get(int id)
        {
            return _set.Find(id);
        }
        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _set.Where(predicate);
        }
        
        public IEnumerable<T> GetAll(params string[] props)
        {

            DbQuery<T> query = props.Aggregate<string, DbQuery<T>>(_set, (current, child) => current.Include(child));
            return query.AsNoTracking().ToList();
        }


    }


}

