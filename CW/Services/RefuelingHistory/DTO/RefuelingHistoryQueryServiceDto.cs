
    using Microsoft.AspNetCore.Mvc;
    public class RefuelingHistoryQueryServiceDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
        
        public int? Id_GT {get; set;}
        
        public int? Id_GTE {get; set;}
        
        public int? Id_LT {get; set;}
        
        public int? Id_LTE {get; set;}
        
        public int? Id_EQ {get; set;}

        
        public decimal? Volume_GT {get; set;}
        
        public decimal? Volume_GTE {get; set;}
        
        public decimal? Volume_LT {get; set;}
        
        public decimal? Volume_LTE {get; set;}
        
        public decimal? Volume_EQ {get; set;}

        
        public short? OilTypeId_GT {get; set;}
        
        public short? OilTypeId_GTE {get; set;}
        
        public short? OilTypeId_LT {get; set;}
        
        public short? OilTypeId_LTE {get; set;}
        
        public short? OilTypeId_EQ {get; set;}


        
        public long? FuelstationTinNumber_GT {get; set;}
        
        public long? FuelstationTinNumber_GTE {get; set;}
        
        public long? FuelstationTinNumber_LT {get; set;}
        
        public long? FuelstationTinNumber_LTE {get; set;}
        
        public long? FuelstationTinNumber_EQ {get; set;}

        
        public int? VehicleId_GT {get; set;}
        
        public int? VehicleId_GTE {get; set;}
        
        public int? VehicleId_LT {get; set;}
        
        public int? VehicleId_LTE {get; set;}
        
        public int? VehicleId_EQ {get; set;}


        
        public decimal? Price_GT {get; set;}
        
        public decimal? Price_GTE {get; set;}
        
        public decimal? Price_LT {get; set;}
        
        public decimal? Price_LTE {get; set;}
        
        public decimal? Price_EQ {get; set;}

        
        public DateTime? Datetime_GT {get; set;}
        
        public DateTime? Datetime_GTE {get; set;}
        
        public DateTime? Datetime_LT {get; set;}
        
        public DateTime? Datetime_LTE {get; set;}
        
        public DateTime? Datetime_EQ {get; set;}

        
        public short? DriverId_GT {get; set;}
        
        public short? DriverId_GTE {get; set;}
        
        public short? DriverId_LT {get; set;}
        
        public short? DriverId_LTE {get; set;}
        
        public short? DriverId_EQ {get; set;}

    }