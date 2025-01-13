using System.Threading.Tasks;
using MyApp.Models;
using Dapper;
using MyApp.Models.Common;
using System.Xml.Linq;
using System.Collections.Generic;
namespace MyApp.BAL
{
    public static class ZoneWiseDataService
    {
        public static List<ZoneWiseDataDto> GetAllList()
        {
            List<ZoneWiseDataDto> res = new List<ZoneWiseDataDto>();
            string _proc = "Proc_ZoneWiseData";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            res = DBHelperDapper.GetAllModelList<ZoneWiseDataDto>(_proc, queryparameter);
            return res;
        }
    }
}
