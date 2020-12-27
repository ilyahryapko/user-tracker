using System.Collections.Generic;
using System.Threading.Tasks;
using UserTracker.BL.Models;
using UserTracker.DAL.Models;
using UserTracker.DAL.Repositories;

namespace UserTracker.BL.Services
{
    public class LogService : ILogService
    {
        private ILogRepository logRepository;
        
        public LogService(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }
        
        public async Task<Log> MakeLogAsync(CreateLogModel model, string userId)
        {
            var log = new Log()
            {
                FromPage = model.FromPage,
                ToPage = model.ToPage,
                Timestamp = model.Timestamp,
                UserId = userId
            };

            await logRepository.InsertOneAsync(log);
            return log;
        }

        public async Task<List<Log>> GetAllLogsAsync()
        {
            return await logRepository.GetAllAsync();
        }

        public async Task<List<Log>> GetUserLogsAsync(string userId)
        {
            return await logRepository.GetByUserIdAsync(userId);
        }
    }
}