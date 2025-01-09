using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;
using X.PagedList.Extensions;

namespace MyApp.Controllers
{
    [CustomAuthenticationFilter]

    public class CommitmentController : BaseController
    {
        public CommitmentController(IConfiguration configuration) : base(configuration)
        {

        }
        public ActionResult Index(int? page = 1)
        {
            List<DailyValueTGTDto> res = DailyValueTGTDtoService.GetAllList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
    }
}
