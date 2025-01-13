using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models.Common;

namespace MyApp.Models
{
    public class WeekNumberDto:BaseDto
    {
        public Guid WeekNoGuid { get; set; }
        public long WeekNoId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string WeekNo { get; set; }
       
    }
}
