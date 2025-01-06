using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MyApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly int PageRecordCount;

        public BaseController(IConfiguration configuration)
        {
            PageRecordCount = int.Parse(configuration["AppSettings:PageRecordCount"] ?? "10");
        }
    }
}
