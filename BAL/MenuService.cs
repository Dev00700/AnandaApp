using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MyApp.Models;
using MyApp.Models.Common;

namespace MyApp.BAL
{
    public static class MenuService
    { 
     
        public static List<MenuDto> GetMenu()
        { 
           List< MenuDto> menuDto = new List<MenuDto>();
            try
            {

                //var res = Crypto.Encrypt("Admin@123");
                string _proc = "Proc_Menu";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 1);
                queryparameter.Add("@userId", 1);
                menuDto = DBHelperDapper.GetAllModelList<MenuDto>(_proc, queryparameter);
                SessionManager.SetMenuList(menuDto);
            }
            catch(Exception ex)
            {
               
            }
           
            return menuDto;
        }
     
    }
}
