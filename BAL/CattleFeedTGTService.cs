using Dapper;
using MyApp.Models.Common;
using MyApp.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MyApp.BAL
{
    public static class CattleFeedTGTService
    {
        public static List<CattleFeedTGTDto> GetAllList()
        {
            List<CattleFeedTGTDto> res = new List<CattleFeedTGTDto>();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<CattleFeedTGTDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Save(CattleFeedTGTDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            //queryparameter.Add("@DICID", dto.DICID);
            //queryparameter.Add("@LineType", dto.LineType);
            //queryparameter.Add("@Date", dto.Date);
            //queryparameter.Add("@ValueTargetPerDay", dto.ValueTargetPerDay);
            //queryparameter.Add("@IsActive", dto.IsActive);
            //queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "CattleFeedTGT parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
      
        public static CattleFeedTGTDto Get(string id)
        {
            CattleFeedTGTDto res = new CattleFeedTGTDto();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@DailyValueGuid", id);
            queryparameter.Add("@ProcId", 3);
            res = DBHelperDapper.GetAllModel<CattleFeedTGTDto>(_proc, queryparameter);
            return res;
        }

        public static CommonResponseDto SaveList(List<CattleFeedTGTDto> dto)
        {
            XElement xml = new XElement("Records",
          dto.ConvertAll(record =>
              new XElement("Record",
                  new XElement("DICID", record.PlantCode),
                  new XElement("LineType", record.FromDate),
                  new XElement("Date", record.ToDate),
                  new XElement("Value", record.WeekNo),
                  new XElement("Value", record.Target),
                  new XElement("IsActive", record.IsActive)

              )
          )
      );

            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 5);
            queryparameter.Add("@XmlData", xml);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "DailyValueTGTDto parameter for saving xml data:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
    }
}
