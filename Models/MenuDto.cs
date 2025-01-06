using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models.Common;
namespace MyApp.Models
{
    public class MenuDto:BaseDto
    {
        public long MenuId { get; set; }
        public Guid MenuGuid { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
       
    }
}
