using MyApp.Models.Common;
using System;

namespace MyApp.Models
{
    public class ClosingBalanceDto :BaseDto
    {
        public Guid ClosingBalanceGuid { get;set; }
        public long PlantMaterialId { get;set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string MeterialCode { get; set; }
        public string MeterialName { get; set; }
        public string Bun { get; set; }
        public string FromDate { get; set;}
        public string ToDate { get; set;}   
        public decimal OpeningStock { get;set;}
        public decimal TotalReceipt { get; set; }
        public decimal TotalIssueQuantities { get;set; }
        public decimal ClosingStock { get;set; }
    }
}
