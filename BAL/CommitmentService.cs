using Dapper;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MyApp.BAL
{
    public class CommitmentService
    {
        public static List<CommitmentDto> GetAllList()
        {
            List<CommitmentDto> res = new List<CommitmentDto>();
            string _proc = "Proc_UDCommitment";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<CommitmentDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Save(CommitmentDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_UDCommitment";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@PlantCodeId", dto.PlantCodeId);
            queryparameter.Add("@FromDate", dto.FromDate);
            queryparameter.Add("@ToDate", dto.ToDate);
            queryparameter.Add("@WeekNoId", dto.WeekNoId);
            queryparameter.Add("@VLCCommitment", dto.VLCCommitment);
            queryparameter.Add("@AMCUCommitment", dto.AMCUCommitment);
            queryparameter.Add("@AMCURecoverd", dto.AMCURecoverd);
            queryparameter.Add("@PerVLCAvg", dto.PerVLCAvg);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "CommitmentDto parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static CommitmentDto Get(string id)
        {
            CommitmentDto res = new CommitmentDto();
            string _proc = "Proc_UDCommitment";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@CommitmentGuid", id);
            queryparameter.Add("@ProcId", 3);
            res = DBHelperDapper.GetAllModel<CommitmentDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Update(CommitmentDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_UDCommitment";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 4);
            queryparameter.Add("@PlantCodeId", dto.PlantCodeId);
            queryparameter.Add("@FromDate", dto.FromDate);
            queryparameter.Add("@ToDate", dto.ToDate);
            queryparameter.Add("@WeekNoId", dto.WeekNoId);
            queryparameter.Add("@VLCCommitment", dto.VLCCommitment);
            queryparameter.Add("@AMCUCommitment", dto.AMCUCommitment);
            queryparameter.Add("@AMCURecoverd", dto.AMCURecoverd);
            queryparameter.Add("@PerVLCAvg", dto.PerVLCAvg);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@CommitmentGuid", dto.CommitmentGuid);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "CommitmentDto parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto SaveList(List<CommitmentDto> dto)
        {
            XElement xml = new XElement("Records",
          dto.ConvertAll(record =>
              new XElement("Record",
                  new XElement("PlantCodeId", record.PlantCodeId),
                  new XElement("FromDate", record.FromDate),
                  new XElement("ToDate", record.ToDate),
                  new XElement("WeekNoId", record.WeekNoId),
                  new XElement("VLCCommitment", record.VLCCommitment),
                  new XElement("AMCUCommitment", record.AMCUCommitment),
                  new XElement("AMCURecoverd", record.AMCURecoverd),
                  new XElement("PerVLCAvg", record.PerVLCAvg),
                  new XElement("IsActive", record.IsActive)

              )
          )
      );

            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_UDCommitment";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 5);
            queryparameter.Add("@XmlData", xml);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "CommitmentDto parameter for saving xml data:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
    }
}
