using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Models.Common;
using MyApp.BAL;
using Microsoft.AspNetCore.Authorization;
using X.PagedList.Extensions;
using MyApp.Models.Base;
using Newtonsoft.Json;
using System.Reflection.Emit;
using Microsoft.Extensions.Configuration;

namespace MyApp.Controllers
{
    [CustomAuthenticationFilter]
    public class EmployeeController : BaseController
    {
        private string MenuCode = "M0003";
        public EmployeeController(IConfiguration configuration) : base(configuration)
        {
        }

        //[HttpGet]
        //public IActionResult Index(int? page)
        //{
        //    List<EmployeeDto> res = EmployeeService.GetEmployeeList();
        //    return View(res.ToPagedList(page ?? 1, 10));
        //}

        [HttpGet]
        public IActionResult Save(string? id)
        {
          
            EmployeeDto res = new EmployeeDto();
            ViewBag.DesiganationId = DropDownService.BindDropDown(1, 0);
            ViewBag.TableauDesignationId = DropDownService.BindDropDown(2, 0);
            ViewBag.ManagerId = DropDownService.BindDropDown(3, 0);
            ViewBag.Button = "Submit";
            res.IsActive=true;
            if (id != null)
            {
                res = EmployeeService.GetEmployee(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }

        public JsonResult Save([FromBody] EmployeeDto employees)
        {
            var result = (CommonResponseDto?)null;
            if (employees.EmployeeGuid == Guid.Empty)
            {
                result = EmployeeService.CheckEmployee(employees.EmployeeCode);
                if (result !=null) //CHEK EMPLOYEE CODE ALREADY EXISTS
                {
                    return Json(result);
                }
            }
                if (employees.EmployeeGuid == Guid.Empty)
                {
                    result = EmployeeService.SaveEmployee(employees);
                }
                else
                {
                    result = EmployeeService.UpdateEmployee(employees);
                }
            
            return Json(result);
        }
        [HttpGet]
        public IActionResult Index(int? page)
        {
            var authres = CommonService.GetAddEditAuthorization(MenuCode);
            ViewBag.Add = authres.ForAdd;
            ViewBag.Edit = authres.ForEdit;
            List<EmployeeDto> res = EmployeeService.GetEmployeeList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
        public IActionResult GetPagedEmployees(int page, int rowperpage, string empCode, string empName,string designation)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = EmployeeService.GetEmployeeList();

            var filters = new Dictionary<string, string>
                   {
                     { "EmployeeCode", empCode },
                     { "EmployeeName", empName },
                     { "DesignationName",designation }
                   };
            IQueryable<EmployeeDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_EmployeeTable", query.ToPagedList(page, pageSize));

        }

        public IActionResult CheckEmpCode( string EmpCode)
        {
            CommonResponseDto res = EmployeeService.CheckEmployee(EmpCode);
            return Json(res);
        }
    }
}
