using MyApp.Models.Common;
using System;

namespace MyApp.Models
{
    public class CattleFeedTGTDto : BaseDto
    {
        public Guid CattleFeedGuid { get; set; }
        public long CattleFeedId { get; set; }
        public long Code { get; set; }
        public long PlantCodeId { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string WeekNo { get; set; }
        public decimal TGTValue { get; set; }

    }
}
