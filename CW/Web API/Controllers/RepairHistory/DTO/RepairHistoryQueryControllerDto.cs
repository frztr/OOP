
    using Microsoft.AspNetCore.Mvc;
    public class RepairHistoryQueryControllerDto
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


        [FromQuery(Name = "DatetimeBegin[gt]")]
        public DateTime? DatetimeBegin_GT {get; set;}
        [FromQuery(Name = "DatetimeBegin[gte]")]
        public DateTime? DatetimeBegin_GTE {get; set;}
        [FromQuery(Name = "DatetimeBegin[lt]")]
        public DateTime? DatetimeBegin_LT {get; set;}
        [FromQuery(Name = "DatetimeBegin[lte]")]
        public DateTime? DatetimeBegin_LTE {get; set;}
        [FromQuery(Name = "DatetimeBegin[eq]")]
        public DateTime? DatetimeBegin_EQ {get; set;}


        [FromQuery(Name = "CompletedWork[eq]")]
        public string? CompletedWork_EQ {get; set;}
        [FromQuery(Name = "CompletedWork[like]")]
        public string? CompletedWork_LIKE {get; set;}





    }