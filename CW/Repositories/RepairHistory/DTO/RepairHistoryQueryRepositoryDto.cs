
    
    public class RepairHistoryQueryRepositoryDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
        
        public int? Id_GT {get; set;}
        
        public int? Id_GTE {get; set;}
        
        public int? Id_LT {get; set;}
        
        public int? Id_LTE {get; set;}
        
        public int? Id_EQ {get; set;}

        
        public int? VehicleId_GT {get; set;}
        
        public int? VehicleId_GTE {get; set;}
        
        public int? VehicleId_LT {get; set;}
        
        public int? VehicleId_LTE {get; set;}
        
        public int? VehicleId_EQ {get; set;}


        
        public DateTime? DatetimeBegin_GT {get; set;}
        
        public DateTime? DatetimeBegin_GTE {get; set;}
        
        public DateTime? DatetimeBegin_LT {get; set;}
        
        public DateTime? DatetimeBegin_LTE {get; set;}
        
        public DateTime? DatetimeBegin_EQ {get; set;}


        
        public string? CompletedWork_EQ {get; set;}
        
        public string? CompletedWork_LIKE {get; set;}





    }