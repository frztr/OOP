
    using Microsoft.AspNetCore.Mvc;
    public class FuelMeasurementHistoryQueryControllerDto
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

        [FromQuery(Name = "MeasurementDate[gt]")]
        public DateTime? MeasurementDate_GT {get; set;}
        [FromQuery(Name = "MeasurementDate[gte]")]
        public DateTime? MeasurementDate_GTE {get; set;}
        [FromQuery(Name = "MeasurementDate[lt]")]
        public DateTime? MeasurementDate_LT {get; set;}
        [FromQuery(Name = "MeasurementDate[lte]")]
        public DateTime? MeasurementDate_LTE {get; set;}
        [FromQuery(Name = "MeasurementDate[eq]")]
        public DateTime? MeasurementDate_EQ {get; set;}

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

    }