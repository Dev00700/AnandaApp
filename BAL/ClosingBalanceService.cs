using Dapper;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MyApp.BAL
{
    public static class ClosingBalanceService 
    {
        public static List<ClosingBalanceDto> GetAllList()
        {
            List<ClosingBalanceDto> res = new List<ClosingBalanceDto>();
            string _proc = "Proc_ClosingBalance";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<ClosingBalanceDto>(_proc, queryparameter);
            return res;
        }
        public static ClosingBalanceDto Get(string id)
        {
            ClosingBalanceDto res = new ClosingBalanceDto();
            string _proc = "Proc_ClosingBalance";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@CattleFeedGuid", id);
            queryparameter.Add("@ProcId", 3);
            res = DBHelperDapper.GetAllModel<ClosingBalanceDto>(_proc, queryparameter);
            return res;
        }

        public static CommonResponseDto SaveList(List<ClosingBalanceDto> dto)
        {
            XElement xml = new XElement("Records",
          dto.ConvertAll(record =>
              new XElement("Record",
                  new XElement("PlantMaterialId", record.PlantMaterialId),
                  new XElement("FromDate", record.FromDate),
                  new XElement("ToDate", record.ToDate),
                  new XElement("OpeningStock", record.OpeningStock),
                  new XElement("TotalReceipt", record.TotalReceipt),
                  new XElement("OpeningStock", record.OpeningStock),
                  new XElement("TotalIssueQuantities", record.TotalIssueQuantities),
                  new XElement("ClosingStock", record.ClosingStock),
                  new XElement("IsActive", record.IsActive)
              )
          )
      );

            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_ClosingBalance";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 5);
            queryparameter.Add("@XmlData", xml);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "Closing Balance parameter for saving xml data:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }


    }
}
