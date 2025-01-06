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
    public class UserController : BaseController
    {
        public UserController(IConfiguration configuration) : base(configuration)
        {
        }
        public ActionResult Index(int? page = 1)
        {
            List<UserDto> res = UserService.GetUserList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }

        // Add or Edit User
        public ActionResult Save(string? id)
        {
            UserDto res = new UserDto();
            ViewBag.Button = "Submit";
            ViewBag.Role = DropDownService.BindDropDown(7, 0);
            res.IsActive = true;
            if (id != null)
            {
                res = UserService.GetUser(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }

        // Save User
        [HttpPost]
        public ActionResult Save([FromBody] UserDto user)
        {
            var result = (CommonResponseDto?)null;
            if (user.UserGuid== Guid.Empty)
            {
               
                result = UserService.SaveUser(user);
            }
            else
            {
                result = UserService.UpdateUser(user);
            }
            return Json(result);
        }
        public IActionResult GetPagedUser(int page,int rowperpage, string userCode, string userName, string email,string mobile)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = UserService.GetUserList();

            var filters = new Dictionary<string, string>
                   {
                     { "UserCode", userCode },
                     { "UserName", userName },
                     { "Email",email },
                     { "MobileNo",mobile }
                   };
            IQueryable<UserDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_UserTable", query.ToPagedList(page, pageSize));

        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
           UserDto user=new UserDto();
            user.UserGuid =Guid.Parse( SessionManager.UserGuid);
            return View(user);
        }
        [HttpPost]
        public IActionResult ChangePassword([FromBody]UserDto user)
        {
            var result=UserService.UpdatePassword(user);
            return Json(result);
        }
    }
}
