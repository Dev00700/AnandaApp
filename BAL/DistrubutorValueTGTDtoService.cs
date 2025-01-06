using Dapper;
using MyApp.Models.Common;
using MyApp.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MyApp.BAL
{
    public static class DistrubutorValueTGTDtoService
    {
        public static List<DistrubutorValueTGTDto> GetALLList()
        {
            List<DistrubutorValueTGTDto> res = new List<DistrubutorValueTGTDto>();
            string _proc = "Proc_DistrubutorValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<DistrubutorValueTGTDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Save(DistrubutorValueTGTDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_DistrubutorValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@DICID", dto.DICID);
            queryparameter.Add("@LineType", dto.LineType);
            queryparameter.Add("@Line", dto.Line);
            queryparameter.Add("@Month", dto.Month);
            queryparameter.Add("@DISTgt", dto.DisTGT);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "Distrubutor ValueTGTDto parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Update(DistrubutorValueTGTDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_DistrubutorValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 4);
            queryparameter.Add("@DICID", dto.DICID);
            queryparameter.Add("@LineType", dto.LineType);
            queryparameter.Add("@Line", dto.Line);
            queryparameter.Add("@Month", dto.Month);
            queryparameter.Add("@DISTgt", dto.DisTGT);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@DistrubutorValueGuid", dto.DistrubutorValueGuid);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "Distrubutor ValueTGTDto parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static DistrubutorValueTGTDto Get(string id)
        {
            DistrubutorValueTGTDto res = new DistrubutorValueTGTDto();
            string _proc = "Proc_DistrubutorValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@DistrubutorValueGuid", id);
            queryparameter.Add("@ProcId", 3);
            res = DBHelperDapper.GetAllModel<DistrubutorValueTGTDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto SaveList(List<DistrubutorValueTGTDto> dto)
        {
            XElement xml = new XElement("Records",
          dto.ConvertAll(record =>
              new XElement("Record",
                  new XElement("DICID", record.DICID),
                   new XElement("Line", record.Line),
                  new XElement("LineType", record.LineType),
                  new XElement("Month", record.Month),
                  new XElement("DisTGT", record.DisTGT)

              )
          )
      );

            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_DistrubutorValueTGT";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 5);
            queryparameter.Add("@XmlData", xml);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "Distrubutor ValueTGTDto parameter for saving xml data:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
    }
}
