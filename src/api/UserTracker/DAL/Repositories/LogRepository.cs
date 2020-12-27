using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using UserTracker.DAL.Models;

namespace UserTracker.DAL.Repositories
{
    public class LogRepository : ILogRepository
    {
        private IConfiguration configuration;
        private IMongoClient mongoClient;
        private IMongoCollection<Log> logs;
        
        public LogRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            var connectionString = this.configuration.GetConnectionString("MongoDbConnection");
            mongoClient = new MongoClient(connectionString);
            IMongoDatabase database = mongoClient.GetDatabase("user-tracker-db");
            logs = database.GetCollection<Log>("logs");
        }
        
        public async Task<Log> InsertOneAsync(Log log)
        {
            await logs.InsertOneAsync(log);
            return log;
        }

        public async Task<List<Log>> GetAllAsync()
        {
            return await logs.Find(x => true).ToListAsync();
        }

        public async Task<List<Log>> GetByUserIdAsync(string userId)
        {
            return await logs.Find(x => x.UserId == userId).ToListAsync();
        }
    }
}