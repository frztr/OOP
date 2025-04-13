
    using Microsoft.AspNetCore.Mvc;
    public class VehicleModelQueryControllerDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
        [FromQuery(Name = "Id[gt]")]
        public int? Id_GT {get; set;}
        [FromQuery(Name = "Id[gte]")]
        public int? Id_GTE {get; set;}
        [FromQuery(Name = "Id[lt]")]
        public int? Id_LT {get; set;}
        [FromQuery(Name = "Id[lte]")]
        public int? Id_LTE {get; set;}
        [FromQuery(Name = "Id[eq]")]
        public int? Id_EQ {get; set;}

        [FromQuery(Name = "Name[eq]")]
        public string? Name_EQ {get; set;}
        [FromQuery(Name = "Name[like]")]
        public string? Name_LIKE {get; set;}

        [FromQuery(Name = "ManufacturerId[gt]")]
        public short? ManufacturerId_GT {get; set;}
        [FromQuery(Name = "ManufacturerId[gte]")]
        public short? ManufacturerId_GTE {get; set;}
        [FromQuery(Name = "ManufacturerId[lt]")]
        public short? ManufacturerId_LT {get; set;}
        [FromQuery(Name = "ManufacturerId[lte]")]
        public short? ManufacturerId_LTE {get; set;}
        [FromQuery(Name = "ManufacturerId[eq]")]
        public short? ManufacturerId_EQ {get; set;}


        [FromQuery(Name = "VehicleCategoryId[gt]")]
        public short? VehicleCategoryId_GT {get; set;}
        [FromQuery(Name = "VehicleCategoryId[gte]")]
        public short? VehicleCategoryId_GTE {get; set;}
        [FromQuery(Name = "VehicleCategoryId[lt]")]
        public short? VehicleCategoryId_LT {get; set;}
        [FromQuery(Name = "VehicleCategoryId[lte]")]
        public short? VehicleCategoryId_LTE {get; set;}
        [FromQuery(Name = "VehicleCategoryId[eq]")]
        public short? VehicleCategoryId_EQ {get; set;}


        [FromQuery(Name = "Power[gt]")]
        public short? Power_GT {get; set;}
        [FromQuery(Name = "Power[gte]")]
        public short? Power_GTE {get; set;}
        [FromQuery(Name = "Power[lt]")]
        public short? Power_LT {get; set;}
        [FromQuery(Name = "Power[lte]")]
        public short? Power_LTE {get; set;}
        [FromQuery(Name = "Power[eq]")]
        public short? Power_EQ {get; set;}

        [FromQuery(Name = "FuelTypeId[gt]")]
        public short? FuelTypeId_GT {get; set;}
        [FromQuery(Name = "FuelTypeId[gte]")]
        public short? FuelTypeId_GTE {get; set;}
        [FromQuery(Name = "FuelTypeId[lt]")]
        public short? FuelTypeId_LT {get; set;}
        [FromQuery(Name = "FuelTypeId[lte]")]
        public short? FuelTypeId_LTE {get; set;}
        [FromQuery(Name = "FuelTypeId[eq]")]
        public short? FuelTypeId_EQ {get; set;}


        [FromQuery(Name = "LoadCapacity[gt]")]
        public int? LoadCapacity_GT {get; set;}
        [FromQuery(Name = "LoadCapacity[gte]")]
        public int? LoadCapacity_GTE {get; set;}
        [FromQuery(Name = "LoadCapacity[lt]")]
        public int? LoadCapacity_LT {get; set;}
        [FromQuery(Name = "LoadCapacity[lte]")]
        public int? LoadCapacity_LTE {get; set;}
        [FromQuery(Name = "LoadCapacity[eq]")]
        public int? LoadCapacity_EQ {get; set;}

    }