using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserTracker.BL.Models;
using UserTracker.BL.Services;
using UserTracker.DAL.Models;
using UserTracker.Models;

namespace UserTracker.Controllers
{
    public class LogsController : BaseController
    {
        private readonly ILogService logService;

        public LogsController(ILogService logService)
        {
            this.logService = logService;
        }

        [HttpPost]
        public async Task<Log> LogAsync([FromBody] CreateLogViewModel createLogViewModel)
        {
            var createLogModel = new CreateLogModel()
            {
                FromPage = createLogViewModel.CurrentPage,
                ToPage = createLogViewModel.NextPage,
                Timestamp = DateTime.UtcNow
            };
            return await logService.MakeLogAsync(createLogModel, CurrentUserId);
        }

        [HttpGet("{all}")]
        public async Task<ActionResult<List<Log>>> GetAllLogsAsync()
        {
            return await logService.GetAllLogsAsync();
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Log>>> GetCurrentUserLogsAsync()
        {
            return await logService.GetUserLogsAsync(CurrentUserId);
        }
    }
}