using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyApp.BAL;
using MyApp.Models;
using MyApp.Models.Base;
using MyApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList.Extensions;

namespace MyApp.Controllers
{
    [CustomAuthenticationFilter]
    public class WeekNumberController : BaseController
    {
        private string MenuCode = "M0015";
        public WeekNumberController(IConfiguration configuration) : base(configuration)
        {

        }
        public IActionResult Index(int? page = 1)
        {
            var authres = CommonService.GetAddEditAuthorization(MenuCode);
            ViewBag.Add = authres.ForAdd;
            ViewBag.Edit = authres.ForEdit;
            List<WeekNumberDto> res = WeekNumberService.GetAllList();
            
            return View(res.ToPagedList(page??1,PageRecordCount));
        }
        public IActionResult GetPagedUser(int page, int rowperpage, string fromdate, string todate, string weekno)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = WeekNumberService.GetAllList();

            var filters = new Dictionary<string, string>
                   {
                     { "FromDate", fromdate },
                     { "ToDate", todate },
                     { "WeekNo", weekno}
                     

                   };
            IQueryable<WeekNumberDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_WeekNumberTable", query.ToPagedList(page, pageSize));

        }

    }
}
