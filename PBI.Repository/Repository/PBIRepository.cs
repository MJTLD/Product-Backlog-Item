using Microsoft.EntityFrameworkCore;
using PBI.Data.EF.Context;
using PBI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBI.Repository.Repository
{
    public class PBIRepository : IPBIRepository
    {

        private readonly PBIContext _context;

        public PBIRepository(PBIContext context)
        {
            _context = context;
        }

        public Task BulkInsertTaskAsync<T>(IList<T> itemsList) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync<T>(T item) where T : class, new()
        {
            _context.Entry(item).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public IQueryable<T> ExecuteCommandAsync<T>(string[] parameters, string name) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get<T>(Func<T, bool> predicate) where T : class, new()
        {
            return _context.Set<T>().Where(predicate).AsQueryable();
        }

        public IQueryable<T> GetAll<T>() where T : class, new()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T> InsertAsync<T>(T item) where T : class, new()
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateAsync<T>(T item) where T : class, new()
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateManyAsync<T>(IList<T> itemsList) where T : class, new()
        {
            _context.UpdateRange(itemsList);
            await _context.SaveChangesAsync();
        }
    }
}
