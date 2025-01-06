using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using Dapper;
using MyApp.Models.Common;

namespace MyApp.BAL
{
    public static class UserService
    {
        public static List<UserDto> GetUserList()
        {
            List<UserDto> res = new List<UserDto>();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<UserDto>(_proc, queryparameter);
            return res;
        }

        public static CommonResponseDto SaveUser(UserDto user)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@UserCode", user.UserCode);
            queryparameter.Add("@UserName", user.UserName);
            queryparameter.Add("@Email", user.Email);
            queryparameter.Add("@Mobile", user.MobileNo);
            queryparameter.Add("@RoleId", user.RoleId);
            queryparameter.Add("@password",Crypto.Encrypt( user.Password));
            queryparameter.Add("@IsActive", user.IsActive);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "User parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static UserDto GetUser(string userguid)
        {
            UserDto res = new UserDto();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 3);
            queryparameter.Add("@UserGuid", userguid);
            CommonFunction.Printparameter(queryparameter, "Get User:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<UserDto>(_proc, queryparameter);
            res.Password = Crypto.Decrypt(res.Password);
            return res;
        }
        public static CommonResponseDto UpdateUser(UserDto user)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 4);
            queryparameter.Add("@UserCode", user.UserCode);
            queryparameter.Add("@UserName", user.UserName);
            queryparameter.Add("@Email", user.Email);
            queryparameter.Add("@Mobile", user.MobileNo);
            queryparameter.Add("@RoleId", user.RoleId);
            queryparameter.Add("@password", user.Password);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            queryparameter.Add("@IsActive", user.IsActive);
            queryparameter.Add("@UserGuid", user.UserGuid);
            CommonFunction.Printparameter(queryparameter, "User parameter for updating:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto UpdatePassword(UserDto user)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_User";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 5);
            queryparameter.Add("@password", Crypto.Encrypt(user.Password));
            queryparameter.Add("@UserGuid", user.UserGuid);
            CommonFunction.Printparameter(queryparameter, "User parameter for updating:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
    }
}
