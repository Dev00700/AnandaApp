using MyApp.Models.Common;
using System;

namespace MyApp.Models
{
    public class ProductCategoryDto : BaseDto
    {
        public Guid ProductCategoryGuid { get; set; }
        public long ProductCategoryId { get; set; }
        public long ProductCategoryCode { get; set; }
        public string ZMGRP { get; set; }
        public string ZSGRP1 { get; set; }
        public string ZSGRP2 { get; set; }
        public string ZSGRP3 { get; set; }
        public string ZSGRP4 { get; set; }
        public string ProductType { get; set; }
        public decimal PackContains { get; set; }
        public decimal ConversionRatio { get; set; }
    }
}