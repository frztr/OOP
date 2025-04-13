
    using Microsoft.AspNetCore.Mvc;
    public class MaintenanceHistoryQueryControllerDto
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

        [FromQuery(Name = "Date[gt]")]
        public DateTime? Date_GT {get; set;}
        [FromQuery(Name = "Date[gte]")]
        public DateTime? Date_GTE {get; set;}
        [FromQuery(Name = "Date[lt]")]
        public DateTime? Date_LT {get; set;}
        [FromQuery(Name = "Date[lte]")]
        public DateTime? Date_LTE {get; set;}
        [FromQuery(Name = "Date[eq]")]
        public DateTime? Date_EQ {get; set;}

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


        [FromQuery(Name = "MaintenanceTypeId[gt]")]
        public short? MaintenanceTypeId_GT {get; set;}
        [FromQuery(Name = "MaintenanceTypeId[gte]")]
        public short? MaintenanceTypeId_GTE {get; set;}
        [FromQuery(Name = "MaintenanceTypeId[lt]")]
        public short? MaintenanceTypeId_LT {get; set;}
        [FromQuery(Name = "MaintenanceTypeId[lte]")]
        public short? MaintenanceTypeId_LTE {get; set;}
        [FromQuery(Name = "MaintenanceTypeId[eq]")]
        public short? MaintenanceTypeId_EQ {get; set;}


        [FromQuery(Name = "CompletedWork[eq]")]
        public string? CompletedWork_EQ {get; set;}
        [FromQuery(Name = "CompletedWork[like]")]
        public string? CompletedWork_LIKE {get; set;}

        [FromQuery(Name = "AutomechanicId[gt]")]
        public short? AutomechanicId_GT {get; set;}
        [FromQuery(Name = "AutomechanicId[gte]")]
        public short? AutomechanicId_GTE {get; set;}
        [FromQuery(Name = "AutomechanicId[lt]")]
        public short? AutomechanicId_LT {get; set;}
        [FromQuery(Name = "AutomechanicId[lte]")]
        public short? AutomechanicId_LTE {get; set;}
        [FromQuery(Name = "AutomechanicId[eq]")]
        public short? AutomechanicId_EQ {get; set;}

    }