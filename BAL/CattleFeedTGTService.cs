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
            string _proc = "Proc_CattleFeedTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<CattleFeedTGTDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Update(CattleFeedTGTDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_CattleFeedTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 4);
            queryparameter.Add("@Code", dto.Code);
            queryparameter.Add("@FromDate", dto.FromDate);
            queryparameter.Add("@ToDate", dto.ToDate);
            queryparameter.Add("@WeekNo", dto.WeekNo);
            queryparameter.Add("@TGTValue", dto.TGTValue);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@CattleFeedGuid", dto.CattleFeedGuid);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "Cattle Feed Target parameter for update:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }

        public static CattleFeedTGTDto Get(string id)
        {
            CattleFeedTGTDto res = new CattleFeedTGTDto();
            string _proc = "Proc_CattleFeedTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@CattleFeedGuid", id);
            queryparameter.Add("@ProcId", 3);
            res = DBHelperDapper.GetAllModel<CattleFeedTGTDto>(_proc, queryparameter);
            return res;
        }

        public static CommonResponseDto SaveList(List<CattleFeedTGTDto> dto)
        {
            XElement xml = new XElement("Records",
          dto.ConvertAll(record =>
              new XElement("Record",
                  new XElement("Code", record.Code),
                  new XElement("PlantCodeId", record.PlantCodeId),
                  new XElement("FromDate", record.FromDate),
                  new XElement("ToDate", record.ToDate),
                  new XElement("WeekNo", record.WeekNo),
                  new XElement("TGTValue", record.TGTValue),
                  new XElement("IsActive", record.IsActive)

              )
          )
      );

            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_CattleFeedTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 5);
            queryparameter.Add("@XmlData", xml);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "CattleFeedTGT parameter for saving xml data:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }


        public static string GetWeekNo(string FromDate, string ToDate)
        {
            string weekno = string.Empty;
            string _proc = "Proc_CattleFeedTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@FromDate", FromDate);
            queryparameter.Add("@ToDate", ToDate);
            queryparameter.Add("@ProcId", 6);
            weekno = DBHelperDapper.GetAllModel<string>(_proc, queryparameter);
            return weekno;
        }
    }
}
