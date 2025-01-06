using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using Dapper;
using MyApp.Models.Common;
namespace MyApp.BAL
{
    public static class LoginService
    {
        public static UserDto Login(string UserName,string Password)
        {
            UserDto res = new UserDto();
            string _proc = "Proc_Login";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@UserName", "Admin");
            queryparameter.Add("@Password", "BQLGE773F69/GxGiWmDnow==");
            res = DBHelperDapper.GetAllModel<UserDto>(_proc, queryparameter);
            if (res.Flag == 0)
            {
                SessionManager.UserId =Convert.ToString( res.UserId);
                SessionManager.UserName =Convert.ToString( res.UserName);
                SessionManager.UserGuid =Convert.ToString( res.UserGuid);
            }
                
            return res;
        }
    }
}
