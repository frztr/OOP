
    using Microsoft.AspNetCore.Mvc;
    public class PlannedMaintenanceScheduleQueryControllerDto
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

        [FromQuery(Name = "PlannedDate[gt]")]
        public DateTime? PlannedDate_GT {get; set;}
        [FromQuery(Name = "PlannedDate[gte]")]
        public DateTime? PlannedDate_GTE {get; set;}
        [FromQuery(Name = "PlannedDate[lt]")]
        public DateTime? PlannedDate_LT {get; set;}
        [FromQuery(Name = "PlannedDate[lte]")]
        public DateTime? PlannedDate_LTE {get; set;}
        [FromQuery(Name = "PlannedDate[eq]")]
        public DateTime? PlannedDate_EQ {get; set;}

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