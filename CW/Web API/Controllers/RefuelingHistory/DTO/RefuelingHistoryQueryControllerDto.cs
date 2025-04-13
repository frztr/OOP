
    using Microsoft.AspNetCore.Mvc;
    public class RefuelingHistoryQueryControllerDto
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

        [FromQuery(Name = "Volume[gt]")]
        public decimal? Volume_GT {get; set;}
        [FromQuery(Name = "Volume[gte]")]
        public decimal? Volume_GTE {get; set;}
        [FromQuery(Name = "Volume[lt]")]
        public decimal? Volume_LT {get; set;}
        [FromQuery(Name = "Volume[lte]")]
        public decimal? Volume_LTE {get; set;}
        [FromQuery(Name = "Volume[eq]")]
        public decimal? Volume_EQ {get; set;}

        [FromQuery(Name = "OilTypeId[gt]")]
        public short? OilTypeId_GT {get; set;}
        [FromQuery(Name = "OilTypeId[gte]")]
        public short? OilTypeId_GTE {get; set;}
        [FromQuery(Name = "OilTypeId[lt]")]
        public short? OilTypeId_LT {get; set;}
        [FromQuery(Name = "OilTypeId[lte]")]
        public short? OilTypeId_LTE {get; set;}
        [FromQuery(Name = "OilTypeId[eq]")]
        public short? OilTypeId_EQ {get; set;}


        [FromQuery(Name = "FuelstationTinNumber[gt]")]
        public long? FuelstationTinNumber_GT {get; set;}
        [FromQuery(Name = "FuelstationTinNumber[gte]")]
        public long? FuelstationTinNumber_GTE {get; set;}
        [FromQuery(Name = "FuelstationTinNumber[lt]")]
        public long? FuelstationTinNumber_LT {get; set;}
        [FromQuery(Name = "FuelstationTinNumber[lte]")]
        public long? FuelstationTinNumber_LTE {get; set;}
        [FromQuery(Name = "FuelstationTinNumber[eq]")]
        public long? FuelstationTinNumber_EQ {get; set;}

        [FromQuery(Name = "VehicleId[gt]")]
        public int? VehicleId_GT {get; set;}
        [FromQuery(Name = "VehicleId[gte]")]
        public int? VehicleId_GTE {get; set;}
        [FromQuery(Name = "VehicleId[lt]")]
        public int? VehicleId_LT {get; set;}
        [FromQuery(Name = "VehicleId[lte]")]
        public int? VehicleId_LTE {get; set;}
        [FromQuery(Name = "VehicleId[eq]")]
        public int? VehicleId_EQ {get; set;}


        [FromQuery(Name = "Price[gt]")]
        public decimal? Price_GT {get; set;}
        [FromQuery(Name = "Price[gte]")]
        public decimal? Price_GTE {get; set;}
        [FromQuery(Name = "Price[lt]")]
        public decimal? Price_LT {get; set;}
        [FromQuery(Name = "Price[lte]")]
        public decimal? Price_LTE {get; set;}
        [FromQuery(Name = "Price[eq]")]
        public decimal? Price_EQ {get; set;}

        [FromQuery(Name = "Datetime[gt]")]
        public DateTime? Datetime_GT {get; set;}
        [FromQuery(Name = "Datetime[gte]")]
        public DateTime? Datetime_GTE {get; set;}
        [FromQuery(Name = "Datetime[lt]")]
        public DateTime? Datetime_LT {get; set;}
        [FromQuery(Name = "Datetime[lte]")]
        public DateTime? Datetime_LTE {get; set;}
        [FromQuery(Name = "Datetime[eq]")]
        public DateTime? Datetime_EQ {get; set;}

        [FromQuery(Name = "DriverId[gt]")]
        public short? DriverId_GT {get; set;}
        [FromQuery(Name = "DriverId[gte]")]
        public short? DriverId_GTE {get; set;}
        [FromQuery(Name = "DriverId[lt]")]
        public short? DriverId_LT {get; set;}
        [FromQuery(Name = "DriverId[lte]")]
        public short? DriverId_LTE {get; set;}
        [FromQuery(Name = "DriverId[eq]")]
        public short? DriverId_EQ {get; set;}

    }