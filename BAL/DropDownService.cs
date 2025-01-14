using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.Models.Common;
using Dapper;
namespace MyApp.BAL
{
    public static class DropDownService
    {
        public static List<DropDownDto> BindDropDown(int ProcId, int ParentId)
        {
            List<DropDownDto> res = new List<DropDownDto>();
            string _proc = "Proc_BindAllDropDown";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", ProcId);
            queryparameter.Add("@ParentId", ParentId);
            res = DBHelperDapper.GetAllModelList<DropDownDto>(_proc, queryparameter);
            return res;
        }
        public static List<DicName> GetMasterDataForAddForm(int ProcId, int ParentId)
        {
            List<DicName> res = new List<DicName>();
            string _proc = "Proc_BindAllDropDown";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", ProcId);
            queryparameter.Add("@ParentId", ParentId);
            res = DBHelperDapper.GetAllModelList<DicName>(_proc, queryparameter);
            return res;
        }
        public static List<PlantName> GetPlantMasterDataForAddForm(int ProcId, int ParentId)
        {
            List<PlantName> res = new List<PlantName>();
            string _proc = "Proc_BindAllDropDown";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", ProcId);
            queryparameter.Add("@ParentId", ParentId);
            res = DBHelperDapper.GetAllModelList<PlantName>(_proc, queryparameter);
            return res;
        }

        public static List<PlantMaterial> GetPlantMaterialDataForAddForm(int ProcId, int ParentId)
        {
            List<PlantMaterial> res = new List<PlantMaterial>();
            string _proc = "Proc_BindAllDropDown";
            var queryparameter = new DynamicParameters();
            queryparameter.Add("@ProcId", ProcId);
            queryparameter.Add("@ParentId", ParentId);
            res = DBHelperDapper.GetAllModelList<PlantMaterial>(_proc, queryparameter);
            return res;
        }
    }
}
