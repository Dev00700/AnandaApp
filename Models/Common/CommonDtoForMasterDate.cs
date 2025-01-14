namespace MyApp.Models.Common
{
    public  class DicName
    {
        public long DicId { get; set; } 
        public string DICName { get; set; } 
    }
    public class PlantName
    {
        public long PlantCodeId { get; set; }
        public string PlantCode { get; set; }
        public string PLANTName { get; set; }
    }

    public class PlantMaterial
    {
        public long PlantMaterialId { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string MeterialCode{get;set;}
        public string MeterialName { get;set; }
        public string Bun { get;set; }
    }
}
