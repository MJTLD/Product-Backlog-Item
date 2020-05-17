using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBI.Repository.IRepository
{
    public interface IPBIRepository
    {
        Task<T> InsertAsync<T>(T item)
            where T : class, new();

        Task<T> UpdateAsync<T>(T item)
            where T : class, new();

        Task UpdateManyAsync<T>(IList<T> itemsList)
            where T : class, new();

        Task<int> DeleteAsync<T>(T item)
            where T : class, new();

        IQueryable<T> Get<T>(Func<T, bool> predicate)
            where T : class, new();

        //Task<T> GetByParamAsync<T>(Func<T, bool> predicate)
        //    where T : class, new();

        IQueryable<T> GetAll<T>() where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">StoreProcedure parameters</param>
        /// <param name="name">StoreProcedure name</param>
        /// <returns></returns>
        IQueryable<T> ExecuteCommandAsync<T>(string[] parameters, string name) where T : class, new();

        Task BulkInsertTaskAsync<T>(IList<T> itemsList)
            where T : class, new();
    }
}
