using Microsoft.AspNetCore.Mvc;
using MyApp.BAL;
using MyApp.Models;
using MyApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList.Extensions;

namespace MyApp.Controllers
{
    [CustomAuthenticationFilter]

    public class ExportCustomerGroupController : Controller
    {
        public ActionResult Index(int? page = 1)
        {
            List<ExportCustomerGroupDto> res = ExportCustomerGroupService.GetAllList();
            return View(res.ToPagedList(page ?? 1, 10));
        }
        public ActionResult Save(string? id)
        {
            ViewBag.DicName = DropDownService.BindDropDown(4, 0);
            ExportCustomerGroupDto res = new ExportCustomerGroupDto();
            ViewBag.Button = "Submit";
            res.IsActive = true;
            if (id != null)
            {
                res = ExportCustomerGroupService.Get(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }
        [HttpPost]
        public ActionResult Save([FromBody] ExportCustomerGroupDto res)
        {
            var result = (CommonResponseDto?)null;
            if (res.ExportCustGrpGuid == Guid.Empty)
            {

                result = ExportCustomerGroupService.Save(res);
            }
            else
            {
                result = ExportCustomerGroupService.Update(res);
            }
            return Json(result);
        }
        public IActionResult GetPagedUser(int page, string custCode, string division, string dic, string lineDET,string linetype, string linetype2)
        {
            var pageSize = 10;
            var res = ExportCustomerGroupService.GetAllList();

            var filters = new Dictionary<string, string>
                   {
                     { "CustCode", custCode },
                     { "Division", division },
                     { "DIC", dic },
                     { "Line_DET", lineDET },
                     { "Line_Type", linetype},
                     { "Line_Type2", linetype2},

                   };
            IQueryable<ExportCustomerGroupDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_ExportCustomerGroup", query.ToPagedList(page, pageSize));

        }
    }
}
