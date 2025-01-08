using Dapper;
using MyApp.Models;
using MyApp.Models.Common;
using System.Collections.Generic;

namespace MyApp.BAL
{
    public class ExportCustomerGroupService
    {
        public static List<ExportCustomerGroupDto> GetAllList()
        {
            List<ExportCustomerGroupDto> res = new List<ExportCustomerGroupDto>();
            string _proc = "Proc_UDExportCustGRP";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 2);
            res = DBHelperDapper.GetAllModelList<ExportCustomerGroupDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Save(ExportCustomerGroupDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_UDExportCustGRP";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 1);
            queryparameter.Add("@CustCode", dto.CustCode);
            queryparameter.Add("@Division", dto.Division);
            queryparameter.Add("@DIC", dto.DIC);
            queryparameter.Add("@Line_DET", dto.Line_DET);
            queryparameter.Add("@LineType", dto.Line_Type);
            queryparameter.Add("@LineType2", dto.Line_Type2);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "ExportCustomerGroupDto parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
        public static ExportCustomerGroupDto Get(string id)
        {
            ExportCustomerGroupDto res = new ExportCustomerGroupDto();
            string _proc = "Proc_UDExportCustGRP";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ExportCustGrpGuid", id);
            queryparameter.Add("@ProcId", 3);
            res = DBHelperDapper.GetAllModel<ExportCustomerGroupDto>(_proc, queryparameter);
            return res;
        }
        public static CommonResponseDto Update(ExportCustomerGroupDto dto)
        {
            CommonResponseDto res = new CommonResponseDto();
            string _proc = "Proc_UDExportCustGRP";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", 4);
            queryparameter.Add("@CustCode", dto.CustCode);
            queryparameter.Add("@Division", dto.Division);
            queryparameter.Add("@DIC", dto.DIC);
            queryparameter.Add("@Line_DET", dto.Line_DET);
            queryparameter.Add("@LineType", dto.Line_Type);
            queryparameter.Add("@LineType2", dto.Line_Type2);
            queryparameter.Add("@IsActive", dto.IsActive);
            queryparameter.Add("@ExportCustGrpGuid", dto.ExportCustGrpGuid);
            queryparameter.Add("@createdBy", SessionManager.UserId);
            CommonFunction.Printparameter(queryparameter, "ExportCustomerGroupDto parameter for saving:");//FOR WRITE LOG'
            res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            return res;
        }
    }
}
