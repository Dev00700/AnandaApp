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
    public class HoshinQltyExpHoldController : BaseController
    {
        public HoshinQltyExpHoldController(IConfiguration configuration) : base(configuration)
        {

        }
        public ActionResult Index(int? page = 1)
        {
            List<HoshinQltyExpHoldDto> res = HoshinQltyExpHoldService.GetAllList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
        public ActionResult Save(string? id)
        {
            ViewBag.DicName = DropDownService.BindDropDown(11, 0);
            HoshinQltyExpHoldDto res = new HoshinQltyExpHoldDto();
            ViewBag.Button = "Submit";
            res.IsActive = true;
            if (id != null)
            {
                res = HoshinQltyExpHoldService.Get(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }
        [HttpPost]
        public ActionResult Save([FromBody] HoshinQltyExpHoldDto res)
        {
            var result = (CommonResponseDto?)null;
            if (res.HoshinQltyExpGuid == Guid.Empty)
            {

                result = HoshinQltyExpHoldService.Save(res);
            }
            return Json(result);
        }
        public IActionResult GetPagedUser(int page, int rowperpage, string Code, string PlantCode, string PlantName, string FromDate,
            string ToDate, string WeekNo, string TGTValue)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = HoshinQltyExpHoldService.GetAllList();

            var filters = new Dictionary<string, string>
                   {
                     { "Code", Code },
                     { "PlantCode", PlantCode },
                     { "PlantName", PlantName},
                     { "FromDate", FromDate},
                     { "ToDate", ToDate},
                     { "WeekNo", WeekNo},
                     { "TGTValue", TGTValue},
                   };

            IQueryable<HoshinQltyExpHoldDto> query = res.AsQueryable();
            query = query.ApplyFilters(filters);
            return PartialView("_CattleFeedTGT", query.ToPagedList(page, pageSize));

        }

        public JsonResult GetPlantName()
        {
            var res = DropDownService.GetPlantMasterDataForAddForm(10, 0);
            var combineresult = new
            {
                masterdata = res,
            };
            return Json(combineresult);
        }
        public ActionResult SaveList([FromBody] List<HoshinQltyExpHoldDto> res)
        {
            var result = (CommonResponseDto?)null;

            result = HoshinQltyExpHoldService.SaveList(res);

            return Json(result);
        }
    }
}