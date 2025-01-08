using MyApp.Models.Common;
using System;

namespace MyApp.Models
{
    public class ExportCustomerGroupDto:BaseDto
    {
        public Guid ExportCustGrpGuid { get; set; }
        public long ExportCustGrpId { get; set; }
        public string CustCode { get; set; }
        public string Division { get; set; }
        public string DIC { get; set; }
        public string Line_DET { get; set; }
        public string Line_Type { get; set; }
        public string Line_Type2 { get; set; }
    }
}
