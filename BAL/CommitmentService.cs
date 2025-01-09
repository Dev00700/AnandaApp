using Dapper;
using MyApp.Models;
using System.Collections.Generic;

namespace MyApp.BAL
{
    public class CommitmentService
    {
        public static List<CommitmentDto> GetAllList()
        {
            List<CommitmentDto> res = new List<CommitmentDto>();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<CommitmentDto>(_proc, queryparameter);
            return res;
        }
    }
}
