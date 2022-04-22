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

        public bool Create(T newEntity)
        {
            try
            {
                _set.Add(newEntity);

                _dbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
     
        public bool Delete(T newEntity)
        {
            try
            {
                _dbContext.Entry(newEntity).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
               
        }
        public bool Delete(int id)
        {
            try
            {
                T realEntity = Get(id);
                if (realEntity != null)
                {
                    _set.Remove(realEntity);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;

            }
            return true;
        }
        // <summary>
        // test
        // </summary>
        //<param name="Entity"></param>
        //<returns> test </returns>
        public bool Update(T Entity)
        {
            try
            {
                _dbContext.Entry(Entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
            
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

