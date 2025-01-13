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
    public static class WeekNumberService
    {
        public static List<WeekNumberDto> GetAllList()
        {
            List<WeekNumberDto> res = new List<WeekNumberDto>();
            string _proc = "Proc_WeekNo";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            res = DBHelperDapper.GetAllModelList<WeekNumberDto>(_proc, queryparameter);
            return res;
        }
    }
}
