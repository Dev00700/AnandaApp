using Dapper;
using MyApp.Models.Common;
using MyApp.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MyApp.BAL
{
    public class HoshinQltyExpHoldService
    {
        public static List<HoshinQltyExpHoldDto> GetAllList()
        {
            List<HoshinQltyExpHoldDto> res = new List<HoshinQltyExpHoldDto>();
            string _proc = "Proc_HoshinQltyExpHold";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<HoshinQltyExpHoldDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Save(HoshinQltyExpHoldDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            //string _proc = "Proc_HoshinQltyExpHold";
            //var queryparameter = new DynamicParameters();
            //queryparameter.Add("@ProcId", 1);
            //queryparameter.Add("@Code", dto.Code);
            //queryparameter.Add("@PlantCodeId", dto.PlantCodeId);
            //queryparameter.Add("@FromDate", dto.FromDate);
            //queryparameter.Add("@ToDate", dto.ToDate);
            //queryparameter.Add("@WeekNo", dto.WeekNo);
            //queryparameter.Add("@TGTValue", dto.TGTValue);
            //queryparameter.Add("@IsActive", dto.IsActive);
            //queryparameter.Add("@createdBy", SessionManager.UserId);
            //CommonFunction.Printparameter(queryparameter, "HoshinQltyExpHold parameter for saving:");//FOR WRITE LOG'
            //res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }

        public static HoshinQltyExpHoldDto Get(string id)
        {
            HoshinQltyExpHoldDto res = new HoshinQltyExpHoldDto();
            string _proc = "Proc_HoshinQltyExpHold";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@HoshinQltyExpGuid", id);
            queryparameter.Add("@ProcId", 3);
            res = DBHelperDapper.GetAllModel<HoshinQltyExpHoldDto>(_proc, queryparameter);
            return res;
        }

        public static CommonResponseDto SaveList(List<HoshinQltyExpHoldDto> dto)
        {
            XElement xml = new XElement("Records",
          dto.ConvertAll(record =>
              new XElement("Record",
                  new XElement("PlantCodeId", record.PlantCodeId),
                  new XElement("Date", record.Date),
                  new XElement("TS", record.TS),
                  new XElement("MBRT", record.MBRT),
                  new XElement("RMV", record.RMV),
                  new XElement("Protine", record.Protine),
                  new XElement("CHHANA", record.CHHANA),
                  new XElement("Temprature", record.Temprature),
                  new XElement("Taste", record.Taste),
                  new XElement("SPC", record.SPC),
                  new XElement("SR_Shift1", record.SR_Shift1),
                  new XElement("SR_Shift2", record.SR_Shift2),
                  new XElement("CHI_EXP", record.CHI_EXP),
                  new XElement("RM_EXP", record.RM_EXP),
                  new XElement("Sal_EXP", record.Sal_EXP),
                  new XElement("Conv_EXP", record.Conv_EXP),
                  new XElement("Cant_EXP", record.Cant_EXP),
                  new XElement("Oth_EXP", record.Oth_EXP),
                  new XElement("Trans_EXP", record.Trans_EXP),
                  new XElement("Qlty_Rate", record.Qlty_Rate),
                  new XElement("AS_Hoshin", record.AS_Hoshin),
                  new XElement("AKS_Hoshin", record.AKS_Hoshin),
                  new XElement("MA_Hoshin", record.MA_Hoshin),
                  new XElement("MC_Hosin", record.MC_Hosin),
                  new XElement("Route_Hoshin", record.Route_Hoshin),
                  new XElement("EKO_Hoshin", record.EKO_Hoshin),
                  new XElement("Aur_Bas_Hoshin", record.Aur_Bas_Hoshin),
                  new XElement("CO_Hoshin", record.CO_Hoshin),
                  new XElement("IsActive", record.IsActive)

              )
          )
      );

            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_HoshinQltyExpHold";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 5);
            queryparameter.Add("@XmlData", xml);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "HoshinQltyExpHold parameter for saving xml data:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
    }
}
