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
    public class ZoneWiseDataController : BaseController
    {
        private string MenuCode = "M0016";
        public ZoneWiseDataController(IConfiguration configuration):base(configuration)
        {
                
        }
        public IActionResult Index(int? page = 1)
        {
            var authres = CommonService.GetAddEditAuthorization(MenuCode);
            ViewBag.Add = authres.ForAdd;
            ViewBag.Edit = authres.ForEdit;
            List<ZoneWiseDataDto> res = ZoneWiseDataService.GetAllList();

            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
        public IActionResult GetPagedUser(int page, int rowperpage, string zone, string oldplantcode, string newplantcode,string plantname,string zonalhead)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = ZoneWiseDataService.GetAllList();

            var filters = new Dictionary<string, string>
                   {
                     { "Zone", zone },
                     { "OldPlantCode", oldplantcode },
                     { "NewPlantCode", newplantcode},
                     { "PlantName", plantname},
                     { "ZonalHead", zonalhead},


                   };
            IQueryable<ZoneWiseDataDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_ZoneWiseDataTable", query.ToPagedList(page, pageSize));

        }

    }
}
