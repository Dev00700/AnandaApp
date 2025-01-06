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
    public class DailyValueTGTController : BaseController
    {
        public DailyValueTGTController(IConfiguration configuration) : base(configuration)
        {
                
        }
        public ActionResult Index(int? page = 1)
        {
            List<DailyValueTGTDto> res = DailyValueTGTDtoService.GetAllList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
        public ActionResult Save(string? id)
        {
            ViewBag.DicName = DropDownService.BindDropDown(4,0);
            DailyValueTGTDto res = new DailyValueTGTDto();
            ViewBag.Button = "Submit";
            res.IsActive = true;
            if (id != null)
            {
                res = DailyValueTGTDtoService.Get(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }
        [HttpPost]
        public ActionResult Save([FromBody] DailyValueTGTDto res)
        {
            var result = (CommonResponseDto?)null;
            if (res.DailyValueGuid == Guid.Empty)
            {

                result = DailyValueTGTDtoService.Save(res);
            }
            else
            {
                result = DailyValueTGTDtoService.Update(res);
            }
            return Json(result);
        }
        public IActionResult GetPagedUser(int page, int rowperpage, string dicname, string linetype ,string date, string valuetarget)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = DailyValueTGTDtoService.GetAllList();

            var filters = new Dictionary<string, string>
                   {
                     { "DICName", dicname },
                     { "LineType", linetype },
                     { "Date", date},
                     { "ValueTargetPerDay", valuetarget},
                     
                   };
            IQueryable<DailyValueTGTDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_DailyValueTGTDto", query.ToPagedList(page, pageSize));

        }

        public JsonResult GetDICName()
        {
           var res = DropDownService.GetMasterDataForAddForm(6, 0);
           return Json(res);
        }
        public ActionResult SaveList([FromBody] List<DailyValueTGTDto> res)
        {
            var result = (CommonResponseDto?)null;
         
                result = DailyValueTGTDtoService.SaveList(res);
          
            return Json(result);
        }
    }
}
