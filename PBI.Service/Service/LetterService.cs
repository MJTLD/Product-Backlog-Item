using System;
using System.Linq;
using System.Threading.Tasks;
using PBI.Model.Secretariat;
using PBI.Repository.IRepository;
using PBI.Service.IService;

namespace PBI.Service.Service
{
    public class LetterService : ILetterService
    {
        private readonly IPBIRepository _repository;
        public LetterService(IPBIRepository repository)
        {
            _repository = repository;
        }

        public int CountAsync()
        {
            return Get(r => r.LetterId > 0).Count();
        }

        public async Task<int> DeleteAsync(Letter item)
        {
            return await _repository.DeleteAsync(item);
        }

        public IQueryable<Letter> Get(Func<Letter, bool> predicate)
        {
            return _repository.Get(predicate).AsQueryable();
        }

        public IQueryable<Letter> GetAll()
        {
            return _repository.GetAll<Letter>().AsQueryable();
        }       

        public async Task<Letter> InsertAsync(Letter item)
        {
            return await _repository.InsertAsync(item);
        }

        public async Task<Letter> UpdateAsync(Letter item)
        {
            return await _repository.UpdateAsync(item);
        }
    }
}