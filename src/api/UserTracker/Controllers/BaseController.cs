using Microsoft.AspNetCore.Mvc;

namespace UserTracker.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected string CurrentUserId => User?.Identity?.Name;
    }
}