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
    public class DistrubutorValueTGTController : BaseController
    {
        private string MenuCode = "M0008";
        public DistrubutorValueTGTController(IConfiguration configuration) : base(configuration)
        {
        }

        public ActionResult Index(int? page = 1)
        {
            var authres = CommonService.GetAddEditAuthorization(MenuCode);
            ViewBag.Add = authres.ForAdd;
            ViewBag.Edit = authres.ForEdit;
            List<DistrubutorValueTGTDto> res = DistrubutorValueTGTDtoService.GetALLList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
        public ActionResult Save(string? id)
        {
            ViewBag.DicName = DropDownService.BindDropDown(4, 0);
            DistrubutorValueTGTDto res = new DistrubutorValueTGTDto();
            ViewBag.Button = "Submit";
            res.IsActive = true;
            if (id != null)
            {
                res = DistrubutorValueTGTDtoService.Get(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }
        [HttpPost]
        public ActionResult Save([FromBody] DistrubutorValueTGTDto res)
        {
            var result = (CommonResponseDto?)null;
            if (res.DistrubutorValueGuid == Guid.Empty)
            {

                result = DistrubutorValueTGTDtoService.Save(res);
            }
            else
            {
                result = DistrubutorValueTGTDtoService.Update(res);
            }
            return Json(result);
        }
        public IActionResult GetPagedUser(int page,int rowperpage, string dicname, string linetype, string month)
        {
            var pageSize = rowperpage !=0? rowperpage: PageRecordCount;
            var res = DistrubutorValueTGTDtoService.GetALLList();

            var filters = new Dictionary<string, string>
                   {
                     { "DICName", dicname },
                     { "LineType", linetype },
                     { "Month", month},
                    // {"DisTGT", distgt}

                   };
            IQueryable<DistrubutorValueTGTDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_DistrubutorValueTGTTable", query.ToPagedList(page, pageSize));

        }
        public JsonResult GetDICName()
        {
            var res = DropDownService.GetMasterDataForAddForm(6, 0);
            var res2 = DropDownService.BindDropDown(8, 0);
            var res3 = DropDownService.BindDropDown(9, 0);
            var combineresult = new
            {
                masterdata = res,
                linetype = res2,
                line = res3
            };
            return Json(combineresult);
        }

        [HttpPost]
        public ActionResult SaveList([FromBody] List<DistrubutorValueTGTDto> res)
        {
            var result = (CommonResponseDto?)null;
            result = DistrubutorValueTGTDtoService.SaveList(res);
            return Json(result);
        }
    }
}
