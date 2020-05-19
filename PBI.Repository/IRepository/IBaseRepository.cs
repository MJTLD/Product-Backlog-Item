using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBI.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<int> DeleteAsync(T item);
        IQueryable<T> Get(Func<T, bool> predicate);
        int CountAsync();
        IQueryable<T> GetAll();
    }
}
