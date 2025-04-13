
    using Microsoft.AspNetCore.Mvc;
    public class MaintenanceHistoryQueryServiceDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
        
        public int? Id_GT {get; set;}
        
        public int? Id_GTE {get; set;}
        
        public int? Id_LT {get; set;}
        
        public int? Id_LTE {get; set;}
        
        public int? Id_EQ {get; set;}

        
        public DateTime? Date_GT {get; set;}
        
        public DateTime? Date_GTE {get; set;}
        
        public DateTime? Date_LT {get; set;}
        
        public DateTime? Date_LTE {get; set;}
        
        public DateTime? Date_EQ {get; set;}

        
        public int? VehicleId_GT {get; set;}
        
        public int? VehicleId_GTE {get; set;}
        
        public int? VehicleId_LT {get; set;}
        
        public int? VehicleId_LTE {get; set;}
        
        public int? VehicleId_EQ {get; set;}


        
        public short? MaintenanceTypeId_GT {get; set;}
        
        public short? MaintenanceTypeId_GTE {get; set;}
        
        public short? MaintenanceTypeId_LT {get; set;}
        
        public short? MaintenanceTypeId_LTE {get; set;}
        
        public short? MaintenanceTypeId_EQ {get; set;}


        
        public string? CompletedWork_EQ {get; set;}
        
        public string? CompletedWork_LIKE {get; set;}

        
        public short? AutomechanicId_GT {get; set;}
        
        public short? AutomechanicId_GTE {get; set;}
        
        public short? AutomechanicId_LT {get; set;}
        
        public short? AutomechanicId_LTE {get; set;}
        
        public short? AutomechanicId_EQ {get; set;}

    }