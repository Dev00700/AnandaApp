using MyApp.Models.Common;
using System;

namespace MyApp.Models
{
    public class HoshinQltyExpHoldDto : BaseDto
    {
        public Guid HoshinQltyExpGuid {  get; set; }
        public long PlantCodeId { get; set; }
        public string Date { get; set; }
        public decimal TS { get; set; }
        public decimal MBRT { get; set; }
        public decimal RMV { get; set; }
        public decimal Protine { get; set; }
        public decimal CHHANA { get; set; }
        public decimal Temprature { get; set; }     
        public decimal Taste { get; set; }
        public decimal SPC { get; set; }
        public decimal SR_Shift1 { get; set; }
        public decimal SR_Shift2 { get; set; }
        public decimal CHI_EXP { get; set; }
        public decimal RM_EXP { get; set; }
        public decimal Sal_EXP { get; set; }
        public decimal Conv_EXP { get; set; }
        public decimal Cant_EXP { get; set; }
        public decimal Oth_EXP { get; set; }
        public decimal Trans_EXP { get; set; }
        public decimal Qlty_Rate { get; set; }
        public decimal AS_Hoshin { get; set; }
        public decimal AKS_Hoshin { get; set; }
        public decimal MA_Hoshin { get; set; }
        public decimal MC_Hosin { get; set; }
        public decimal Route_Hoshin { get; set; }
        public decimal EKO_Hoshin { get; set; }
        public decimal Aur_Bas_Hoshin   { get; set; }
        public decimal CO_Hoshin   { get; set; }
    }
}
