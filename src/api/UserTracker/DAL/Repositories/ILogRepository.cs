using System.Collections.Generic;
using System.Threading.Tasks;
using UserTracker.DAL.Models;

namespace UserTracker.DAL.Repositories
{
    public interface ILogRepository
    {
        public Task<Log> InsertOneAsync(Log log);
        public Task<List<Log>> GetAllAsync();
        public Task<List<Log>> GetByUserIdAsync(string userId);
    }
}