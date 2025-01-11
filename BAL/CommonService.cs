using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using Dapper;
using MyApp.Models.Common;
using System.Xml.Linq;

namespace MyApp.BAL
{
    public static class CommonService
    {
        public static UserMenuAuthorizationDto GetAddEditAuthorization(string MenuCode)
        {
            UserMenuAuthorizationDto res = new UserMenuAuthorizationDto();
            string _proc = "Proc_Menu";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@procId", 2);
            queryparameter.Add("@MenuCode", MenuCode);
            queryparameter.Add("@UserId", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "User parameter for Get Menu Add/Edit:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<UserMenuAuthorizationDto>(_proc, queryparameter);
            return res;
        }
    }
}
