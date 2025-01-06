using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyApp.BAL;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList.Extensions;

namespace MyApp.Controllers
{
    [CustomAuthenticationFilter]
    public class UserMenuAuthorizationController : Controller
    {
        [HttpGet]
        
        [HttpPost]
        public JsonResult Save([FromBody] List<UserMenuAuthorizationDto> userMenuAuthorizationDtos)
        {
            List<CommonResponseDto> results = new List<CommonResponseDto>();

            try
            {
                List<UserMenuAuthorizationDto> itemsToSave = new List<UserMenuAuthorizationDto>();
                List<UserMenuAuthorizationDto> itemsToUpdate = new List<UserMenuAuthorizationDto>();
                foreach (var userMenuAuthorizationDto in userMenuAuthorizationDtos)
                {
                    var result = UserMenuAuthorizationService.CheckUserMenuAuthorization(userMenuAuthorizationDto.UserMenuId);
                    if (result == null || result.Flag != 2) 
                    {
                        itemsToSave.Add(userMenuAuthorizationDto);
                    }
                    else
                    {
                        itemsToUpdate.Add(userMenuAuthorizationDto);
                    }
                }

                if (itemsToSave.Any())
                {
                    var saveResults = UserMenuAuthorizationService.SaveUserMenuAuthorization(itemsToSave);
                    if (saveResults != null && saveResults.Any())
                    {
                        results.AddRange(saveResults);
                    }
                }
                if (itemsToUpdate.Any())
                {
                    var updateResults = UserMenuAuthorizationService.UpdateUserMenuAuthorization(itemsToUpdate);
                    if (updateResults != null && updateResults.Any())
                    {
                        results.AddRange(updateResults);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Flag = 0, // 0: Failure
                    Message = $"An error occurred while saving the data: {ex.Message}"
                });
            }
            return Json(results);
        }




        [HttpGet]
        
        public IActionResult Index(string? id)
        {
            UserMenuAuthorizationDto res = new UserMenuAuthorizationDto();
            ViewBag.UserDetails = DropDownService.BindDropDown(4, 0);
            ViewBag.Button = string.IsNullOrEmpty(id) ? "Submit" : "Update";

            
            return View(res); // For the form
        }
        public JsonResult GetMenus(string? userId)
        {
            List<UserMenuAuthorizationDto> userMenuAuthorizations = UserMenuAuthorizationService.GetUserMenuAuthorizationsList();

            //List<UserMenuAuthorizationDto> selectedAuthorization = new List<UserMenuAuthorizationDto>
            //{
            //    IsActive = true // Default values
            //};
            if (!string.IsNullOrEmpty(userId))
            {
                userMenuAuthorizations = UserMenuAuthorizationService.GetUserMenuAuthorization(userId);
            }

            return Json(userMenuAuthorizations);
        }
        public IActionResult CheckUserMenuAuthorization(long MenuId)
        {
            CommonResponseDto res = UserMenuAuthorizationService.CheckUserMenuAuthorization(MenuId);
            return Json(res);
        }
    }
}
