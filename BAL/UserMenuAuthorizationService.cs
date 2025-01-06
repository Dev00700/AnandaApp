using Dapper;
using MyApp.Models;
using System.Collections.Generic;
using System;
using MyApp.Models.Common;
using Azure;

namespace MyApp.BAL
{
    public class UserMenuAuthorizationService
    {
        public static List<UserMenuAuthorizationDto> GetUserMenuAuthorizationsList()
        {
            List<UserMenuAuthorizationDto> res = new List<UserMenuAuthorizationDto>();
            try
            {
                string _proc = "Proc_UserMenuAuthorization";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 2);
                res = DBHelperDapper.GetAllModelList<UserMenuAuthorizationDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }
        public static List<CommonResponseDto> SaveUserMenuAuthorization(List<UserMenuAuthorizationDto> userMenuAuthorizationDtos)
        {
            List<CommonResponseDto> responses = new List<CommonResponseDto>();

            try
            {
                foreach (var userMenuAuthorizationDto in userMenuAuthorizationDtos)
                {
                    string _proc = "Proc_UserMenuAuthorization";
                    var queryparameter = new DynamicParameters();
                    queryparameter.Add("@ProcId", 1);
                    queryparameter.Add("@MenuId", userMenuAuthorizationDto.MenuId);
                    queryparameter.Add("@UserId", userMenuAuthorizationDto.UserId);
                    queryparameter.Add("@ForAdd", userMenuAuthorizationDto.ForAdd);
                    queryparameter.Add("@ForEdit", userMenuAuthorizationDto.ForEdit);
                    queryparameter.Add("@UserMenuGuid", Guid.NewGuid());
                    queryparameter.Add("@CreatedBy", SessionManager.UserId);
                    queryparameter.Add("@CreatedOn", DateTime.Now);
                    queryparameter.Add("@ModifiedOn", DateTime.Now);
                    queryparameter.Add("@ModifiedBy", SessionManager.UserId);
                    queryparameter.Add("@IsActive", 1);
                    CommonFunction.Printparameter(queryparameter, "UserMenuAuthorization parameters for Saving:");
                    var response = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
                    responses.Add(response);
                }
            }
            catch (Exception ex) { }
            return responses;
        }
        public static List<UserMenuAuthorizationDto> GetUserMenuAuthorization(string userId)
        {
            List<UserMenuAuthorizationDto> res = new List<UserMenuAuthorizationDto>();
            try
            {
                string _proc = "Proc_UserMenuAuthorization";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 6);
                queryparameter.Add("@UserId", userId);
                CommonFunction.Printparameter(queryparameter, "Get UserMenuAuthorization:");//FOR WRITE LOG'
                res = DBHelperDapper.GetAllModelList<UserMenuAuthorizationDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }

        public static List<CommonResponseDto> UpdateUserMenuAuthorization(List<UserMenuAuthorizationDto> userMenuAuthorizationDtos)
        {
            List<CommonResponseDto> responses = new List<CommonResponseDto>();

            try
            {
                foreach (var userMenuAuthorizationDto in userMenuAuthorizationDtos)
                {
                    var createdOn = DBHelperDapper.GetColumnValueById<DateTime?>(
                                    "ULUserMenuAuthorization",  
                                    "CreatedOn",                
                                    "UserMenuId",               
                                    userMenuAuthorizationDto.UserMenuId );
                    var createdBy = DBHelperDapper.GetColumnValueById<string?>(
                                    "ULUserMenuAuthorization",
                                    "CreatedBy",
                                    "UserMenuId",
                                    userMenuAuthorizationDto.UserMenuId);

                    string _proc = "Proc_UserMenuAuthorization";
                    var queryparameter = new DynamicParameters();
                    queryparameter.Add("@ProcId", 4);
                    queryparameter.Add("@MenuId", userMenuAuthorizationDto.MenuId);
                    queryparameter.Add("@UserId", userMenuAuthorizationDto.UserId);
                    queryparameter.Add("@ForAdd", userMenuAuthorizationDto.ForAdd);
                    queryparameter.Add("@ForEdit", userMenuAuthorizationDto.ForEdit);
                    queryparameter.Add("@UserMenuGuid", userMenuAuthorizationDto.UserMenuGuid);
                    queryparameter.Add("@UserMenuId", userMenuAuthorizationDto.UserMenuId);
                    queryparameter.Add("@CreatedBy", createdBy);
                    queryparameter.Add("@CreatedOn", createdOn);
                    queryparameter.Add("@ModifiedOn", DateTime.Now);
                    queryparameter.Add("@ModifiedBy", SessionManager.UserId);
                    queryparameter.Add("@IsActive", userMenuAuthorizationDto.IsActive);
                    queryparameter.Add("@Delmark", userMenuAuthorizationDto.DelMark);
                    CommonFunction.Printparameter(queryparameter, "UserMenuAuthorization parameters for updating:");
                    var response = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
                    responses.Add(response);
                }
            }
            catch (Exception ex)
            {

            }

            return responses;
        }


        public static CommonResponseDto CheckUserMenuAuthorization(long UserMenuId)
        {
            CommonResponseDto res = new CommonResponseDto();
            try
            {
                string _proc = "Proc_UserMenuAuthorization";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 5);
                queryparameter.Add("@UserMenuId", UserMenuId);
                res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }

    }
}
