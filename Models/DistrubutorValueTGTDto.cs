using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models.Common;
namespace MyApp.Models
{
    public class DistrubutorValueTGTDto:BaseDto
    {
        public Guid DistrubutorValueGuid { get; set; }
        public long DistrubutorValueId { get; set; }
        public long DICID { get; set; }
        public string DICName { get; set; }
        public string Line { get; set; }
        public string LineType { get; set; }
        public string Month { get; set; }
        public decimal DisTGT { get; set; }
      
        
    }
}
