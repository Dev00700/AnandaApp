using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

    public class CommitmentController : BaseController
    {
        public CommitmentController(IConfiguration configuration) : base(configuration)
        {

        }
        public ActionResult Index(int? page = 1)
        {
            List<CommitmentDto> res = CommitmentService.GetAllList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
        public ActionResult Save(string? id)
        {
            ViewBag.PlantCode = DropDownService.BindDropDown(11, 0);

            CommitmentDto res = new CommitmentDto();
            ViewBag.Button = "Submit";
            res.IsActive = true;
            if (id != null)
            {
                res = CommitmentService.Get(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }
        [HttpPost]
        public ActionResult Save([FromBody] CommitmentDto res)
        {
            var result = (CommonResponseDto?)null;
            if (res.CommitmentGuid == Guid.Empty)
            {

                result = CommitmentService.Save(res);
            }
            else
            {
                result = CommitmentService.Update(res);
            }
            return Json(result);
        }
        public IActionResult GetPagedUser(int page, int rowperpage, string dicname, string linetype, string date, string valuetarget)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = CommitmentService.GetAllList();

            var filters = new Dictionary<string, string>
                   {
                     { "DICName", dicname },
                     { "LineType", linetype },
                     { "Date", date},
                     { "ValueTargetPerDay", valuetarget},

                   };
            IQueryable<CommitmentDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_CommitmentDto", query.ToPagedList(page, pageSize));

        }
        //public JsonResult GetDICName()
        //{
        //    var res = DropDownService.GetMasterDataForAddForm(6, 0);
        //    var res2 = DropDownService.BindDropDown(8, 0);
        //    var combineresult = new
        //    {
        //        masterdata = res,
        //        dropdown = res2
        //    };
        //    return Json(combineresult);
        //}
        public ActionResult SaveList([FromBody] List<CommitmentDto> res)
        {
            var result = (CommonResponseDto?)null;

            result = CommitmentService.SaveList(res);

            return Json(result);
        }
    }
}
