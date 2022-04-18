using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.DAL.Interfaces
{
    public interface IDataGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(params string[] props);
        T Get(int id);
        void Create(T newEntity);
        void Delete(T newEntity);
        void Delete(int id);
        void SaveChange(T Entity);
    }
}
