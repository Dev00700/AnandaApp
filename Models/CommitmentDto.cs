using MyApp.Models.Common;
using System;

namespace MyApp.BAL
{
    public class CommitmentDto:BaseDto
    {
        public Guid CommitmentGuid { get; set; }

        public long CommitmentId { get; set; }
        public string PlantCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Weekno { get; set; }
        public decimal VLCCommitment { get; set; }
        public decimal AMCUCommitment { get; set; }
        public decimal AMCURecoverd { get; set; }
        public decimal PerVLCAvg { get; set; }
    }
}
