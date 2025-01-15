using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using MyApp.Models.Base;
using X.PagedList.Extensions;

namespace MyApp.Controllers
{
    [CustomAuthenticationFilter]
    public class ClosingBalanceController : BaseController
    {
        public ClosingBalanceController(IConfiguration configuration) : base(configuration)
        {

        }
        public ActionResult Index(int? page = 1)
        {
            List<ClosingBalanceDto> res = ClosingBalanceService.GetAllList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }

        public ActionResult Save(string? id)
        {
            ClosingBalanceDto res = new ClosingBalanceDto();
            ViewBag.Button = "Submit";
            res.IsActive = true;
            if (id != null)
            {
                res = ClosingBalanceService.Get(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }

        [HttpPost]
        public ActionResult Save([FromBody] ClosingBalanceDto res)
        {
            var result = (CommonResponseDto?)null;
            if (res.ClosingBalanceGuid != Guid.Empty)
            {

                result = ClosingBalanceService.Update(res);
            }
           
            return Json(result);
        }


        public IActionResult GetPagedUser(int page, int rowperpage, string PlantCode, string PlantName, string MeterialCode, string MeterialName, string FromDate,
            string ToDate, string OpeningStock, string ClosingStock)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = ClosingBalanceService.GetAllList();

            var filters = new Dictionary<string, string>
                   {
                     { "PlantCode", PlantCode },
                     { "PlantName", PlantName},
                     { "MeterialCode", MeterialCode},
                     { "MeterialName", MeterialName},
                     { "FromDate", FromDate},
                     { "ToDate", ToDate},
                     { "OpeningStock", OpeningStock},
                     { "ClosingStock", ClosingStock},
                   };

            IQueryable<ClosingBalanceDto> query = res.AsQueryable();
            query = query.ApplyFilters(filters);
            return PartialView("_ClosingBalanceTable", query.ToPagedList(page, pageSize));

        }

        public JsonResult GetPlantMaterial()
        {
            var res = DropDownService.GetPlantMaterialDataForAddForm(13, 0);
            var combineresult = new
            {
                masterdata = res,
            };
            return Json(combineresult);
        }
        public ActionResult SaveList([FromBody] List<ClosingBalanceDto> res)
        {
            var result = (CommonResponseDto?)null;

            result = ClosingBalanceService.SaveList(res);

            return Json(result);
        }
    }
}
