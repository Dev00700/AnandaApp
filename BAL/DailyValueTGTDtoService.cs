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
    public static class DailyValueTGTDtoService
    {
        public static List<DailyValueTGTDto> GetAllList()
        {
            List<DailyValueTGTDto> res = new List<DailyValueTGTDto>();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<DailyValueTGTDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Save(DailyValueTGTDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@DICID", dto.DICID);
            queryparameter.Add("@LineType", dto.LineType);
            queryparameter.Add("@Date", dto.Date);
            queryparameter.Add("@ValueTargetPerDay", dto.ValueTargetPerDay);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "DailyValueTGTDto parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Update(DailyValueTGTDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 4);
            queryparameter.Add("@DICID", dto.DICID);
            queryparameter.Add("@LineType", dto.LineType);
            queryparameter.Add("@Date", dto.Date);
            queryparameter.Add("@ValueTargetPerDay", dto.ValueTargetPerDay);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@DailyValueGuid", dto.DailyValueGuid);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "DailyValueTGTDto parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static DailyValueTGTDto Get(string id)
        {
            DailyValueTGTDto res = new DailyValueTGTDto();
            string _proc = "Proc_DailyValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@DailyValueGuid", id);
            queryparameter.Add("@ProcId", 3);
            res = DBHelperDapper.GetAllModel<DailyValueTGTDto>(_proc, queryparameter);
            return res;
        }

        public static CommonResponseDto SaveList(List<DailyValueTGTDto> dto)
        {
            XElement xml = new XElement("Records",
          dto.ConvertAll(record =>
              new XElement("Record",
                  new XElement("DICID", record.DICID),
                  new XElement("LineType", record.LineType),
                  new XElement("Date", record.Date),
                  new XElement("Value", record.ValueTargetPerDay),
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
