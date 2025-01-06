using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using Dapper;
using MyApp.Models.Common;
using System.Reflection.Emit;

namespace MyApp.BAL
{
    public static class EmployeeService
    {
        public static List<EmployeeDto> GetEmployeeList()
        {
            List<EmployeeDto> res = new List<EmployeeDto>();
            try
            {
                string _proc = "Proc_Employee";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 2);
                res = DBHelperDapper.GetAllModelList<EmployeeDto>(_proc, queryparameter);
            } catch (Exception ex) { }
            return res;
        }

        public static CommonResponseDto SaveEmployee(EmployeeDto employee)
        {
            CommonResponseDto res = new CommonResponseDto();
            try
            {
                string _proc = "Proc_Employee";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 1);
                queryparameter.Add("@EmpCode", employee.EmployeeCode);
                queryparameter.Add("@EmpName", employee.EmployeeName);
                queryparameter.Add("@DesignationId", employee.DesignationId);
                queryparameter.Add("@TableauDesignationId", employee.TableauDesignationId);
                queryparameter.Add("@ManagerId", employee.ManagerId);
                queryparameter.Add("@DateofJoining", employee.DateofJoining);
                queryparameter.Add("@Dateofleaving", employee.Dateofleaving);
                queryparameter.Add("@IsActive", employee.IsActive);
                queryparameter.Add("@createdBy", SessionManager.UserId);
                CommonFunction.Printparameter(queryparameter, "Employee paramer for saving:");//FOR WRITE LOG'
                res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }
        public static EmployeeDto GetEmployee(string empguid)
        {
            EmployeeDto res = new EmployeeDto();
            try
            {
                string _proc = "Proc_Employee";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 3);
                queryparameter.Add("@EmpGuid", empguid);
                CommonFunction.Printparameter(queryparameter, "Get Employee:");//FOR WRITE LOG'
                res = DBHelperDapper.GetAllModel<EmployeeDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }    
            return res;
        }
        public static CommonResponseDto UpdateEmployee(EmployeeDto employee)
        {
            CommonResponseDto res = new CommonResponseDto();
            try
            {
                string _proc = "Proc_Employee";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 4);
                queryparameter.Add("@EmpCode", employee.EmployeeCode);
                queryparameter.Add("@EmpName", employee.EmployeeName);
                queryparameter.Add("@DesignationId", employee.DesignationId);
                queryparameter.Add("@TableauDesignationId", employee.TableauDesignationId);
                queryparameter.Add("@ManagerId", employee.ManagerId);
                queryparameter.Add("@DateofJoining", employee.DateofJoining);
                queryparameter.Add("@Dateofleaving", employee.Dateofleaving);
                queryparameter.Add("@createdBy", SessionManager.UserId);
                queryparameter.Add("@IsActive", employee.IsActive);
                queryparameter.Add("@EmpGuid", employee.EmployeeGuid);
                CommonFunction.Printparameter(queryparameter, "Employee paramer for updating:");//FOR WRITE LOG'
                res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            }catch (Exception ex) { }   
            return res;
        }

        public static CommonResponseDto CheckEmployee(string empcode)
        {
            CommonResponseDto res = new CommonResponseDto();
            try
            {
                string _proc = "Proc_Employee";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 5);
                queryparameter.Add("@EmpCode", empcode);
                res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            }catch (Exception ex) { }
            return res;
        }
    }
}
