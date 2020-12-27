using System.Collections.Generic;
using System.Threading.Tasks;
using UserTracker.BL.Models;
using UserTracker.DAL.Models;

namespace UserTracker.BL.Services
{
    public interface ILogService
    {
        public Task<Log> MakeLogAsync(CreateLogModel model, string userId);
        public Task<List<Log>> GetAllLogsAsync();
        public Task<List<Log>> GetUserLogsAsync(string userId);
    }
}