using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models.Common;
namespace MyApp.Models
{
    public class EmployeeDto:BaseDto
    {
        public Guid EmployeeGuid { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int DesignationId { get; set; }
        public int TableauDesignationId { get; set; }
        public int ManagerId { get; set; }
        public string DateofJoining { get; set; }
        public string Dateofleaving { get; set; }
        public string DesignationName { get; set; }
        public string TablueName { get; set; }
        public string ManagerName { get; set; }
        public bool IsActive { get; set; }
       
    }
}
