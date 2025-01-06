using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models.Common;
namespace MyApp.Models
{
    public class DailyValueTGTDto:BaseDto
    {
        public Guid DailyValueGuid { get; set; }
        public long DailyValueId { get; set; }
        public long DICID { get; set; }
        public string LineType { get; set; }
        public string DICName { get; set; }
        public string Date { get; set; }
        public decimal ValueTargetPerDay { get; set; }
        
        
    }
}
