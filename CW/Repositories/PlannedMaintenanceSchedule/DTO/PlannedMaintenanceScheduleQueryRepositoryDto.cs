
    
    public class PlannedMaintenanceScheduleQueryRepositoryDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
        
        public int? Id_GT {get; set;}
        
        public int? Id_GTE {get; set;}
        
        public int? Id_LT {get; set;}
        
        public int? Id_LTE {get; set;}
        
        public int? Id_EQ {get; set;}

        
        public DateTime? PlannedDate_GT {get; set;}
        
        public DateTime? PlannedDate_GTE {get; set;}
        
        public DateTime? PlannedDate_LT {get; set;}
        
        public DateTime? PlannedDate_LTE {get; set;}
        
        public DateTime? PlannedDate_EQ {get; set;}

        
        public short? MaintenanceTypeId_GT {get; set;}
        
        public short? MaintenanceTypeId_GTE {get; set;}
        
        public short? MaintenanceTypeId_LT {get; set;}
        
        public short? MaintenanceTypeId_LTE {get; set;}
        
        public short? MaintenanceTypeId_EQ {get; set;}


        
        public int? VehicleId_GT {get; set;}
        
        public int? VehicleId_GTE {get; set;}
        
        public int? VehicleId_LT {get; set;}
        
        public int? VehicleId_LTE {get; set;}
        
        public int? VehicleId_EQ {get; set;}

    }