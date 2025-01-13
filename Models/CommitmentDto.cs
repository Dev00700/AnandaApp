using MyApp.Models.Common;
using System;

namespace MyApp.Models
{
    public class CommitmentDto:BaseDto
    {
        public Guid CommitmentGuid { get; set; }

        public long CommitmentId { get; set; }
        public long PlantCodeId { get; set; }
        public string? PlantCode { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public long WeekNoId { get; set; }
        public string? WeekNo { get; set; }
        public decimal VLCCommitment { get; set; }
        public decimal AMCUCommitment { get; set; }
        public decimal AMCURecoverd { get; set; }
        public decimal PerVLCAvg { get; set; }
    }
}
