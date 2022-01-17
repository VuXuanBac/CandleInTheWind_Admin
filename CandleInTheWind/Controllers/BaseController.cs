using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace CandleInTheWind.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDistributedCache _cache;
        public BaseController(IDistributedCache cache)
        {
            _cache = cache;
        }
        protected bool HasNotSignIn()
        {
            return (_cache.GetString("login_admin") == null);
        }
    }
}
