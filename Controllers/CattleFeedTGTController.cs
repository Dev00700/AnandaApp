using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using X.PagedList.Extensions;
using MyApp.Models.Base;

namespace MyApp.Controllers
{
    [CustomAuthenticationFilter]
    public class CattleFeedTGTController : BaseController
    {
        public CattleFeedTGTController(IConfiguration configuration) : base(configuration)
        {

        }
        public ActionResult Index(int? page = 1)
        {
            List<CattleFeedTGTDto> res = CattleFeedTGTService.GetAllList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
        public ActionResult Save(string? id)
        {
            ViewBag.DicName = DropDownService.BindDropDown(11, 0);
            CattleFeedTGTDto res = new CattleFeedTGTDto();
            ViewBag.Button = "Submit";
            res.IsActive = true;
            if (id != null)
            {
                res = CattleFeedTGTService.Get(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }
        [HttpPost]
        public ActionResult Save([FromBody] CattleFeedTGTDto res)
        {
            var result = (CommonResponseDto?)null;
            if (res.CattleFeedGuid == Guid.Empty)
            {

                result = CattleFeedTGTService.Save(res);
            }
            return Json(result);
        }
        public IActionResult GetPagedUser(int page, int rowperpage, string dicname, string linetype, string date, string valuetarget)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = CattleFeedTGTService.GetAllList();

            var filters = new Dictionary<string, string>
                   {
                     { "DICName", dicname },
                     { "LineType", linetype },
                     { "Date", date},
                     { "ValueTargetPerDay", valuetarget},
                   };

            IQueryable<CattleFeedTGTDto> query = res.AsQueryable(); 
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
        public ActionResult SaveList([FromBody] List<CattleFeedTGTDto> res)
        {
            var result = (CommonResponseDto?)null;

            result = CattleFeedTGTService.SaveList(res);

            return Json(result);
        }
    }
}