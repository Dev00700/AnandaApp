using System;
using System.Threading.Tasks;
using MyApp.Models.Common;

namespace MyApp.Models
{
    public class ZoneWiseDataDto:BaseDto
    {
        public Guid ZoneWiseGuid { get; set; }
        public long ZoneWiseId { get; set; }
        public string Zone { get; set; }
        public string OldPlantCode { get; set; }
        public string NewPlantCode { get; set; }
        public string PlantName { get; set; }
        public string ZonalHead { get; set; }
     
    }
}
