
    using Microsoft.AspNetCore.Mvc;
    public class VehicleModelQueryServiceDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
        
        public int? Id_GT {get; set;}
        
        public int? Id_GTE {get; set;}
        
        public int? Id_LT {get; set;}
        
        public int? Id_LTE {get; set;}
        
        public int? Id_EQ {get; set;}

        
        public string? Name_EQ {get; set;}
        
        public string? Name_LIKE {get; set;}

        
        public short? ManufacturerId_GT {get; set;}
        
        public short? ManufacturerId_GTE {get; set;}
        
        public short? ManufacturerId_LT {get; set;}
        
        public short? ManufacturerId_LTE {get; set;}
        
        public short? ManufacturerId_EQ {get; set;}


        
        public short? VehicleCategoryId_GT {get; set;}
        
        public short? VehicleCategoryId_GTE {get; set;}
        
        public short? VehicleCategoryId_LT {get; set;}
        
        public short? VehicleCategoryId_LTE {get; set;}
        
        public short? VehicleCategoryId_EQ {get; set;}


        
        public short? Power_GT {get; set;}
        
        public short? Power_GTE {get; set;}
        
        public short? Power_LT {get; set;}
        
        public short? Power_LTE {get; set;}
        
        public short? Power_EQ {get; set;}

        
        public short? FuelTypeId_GT {get; set;}
        
        public short? FuelTypeId_GTE {get; set;}
        
        public short? FuelTypeId_LT {get; set;}
        
        public short? FuelTypeId_LTE {get; set;}
        
        public short? FuelTypeId_EQ {get; set;}


        
        public int? LoadCapacity_GT {get; set;}
        
        public int? LoadCapacity_GTE {get; set;}
        
        public int? LoadCapacity_LT {get; set;}
        
        public int? LoadCapacity_LTE {get; set;}
        
        public int? LoadCapacity_EQ {get; set;}

    }