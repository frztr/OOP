
    
    public class MileageMeasurementHistoryQueryRepositoryDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
        
        public int? Id_GT {get; set;}
        
        public int? Id_GTE {get; set;}
        
        public int? Id_LT {get; set;}
        
        public int? Id_LTE {get; set;}
        
        public int? Id_EQ {get; set;}

        
        public decimal? KmCount_GT {get; set;}
        
        public decimal? KmCount_GTE {get; set;}
        
        public decimal? KmCount_LT {get; set;}
        
        public decimal? KmCount_LTE {get; set;}
        
        public decimal? KmCount_EQ {get; set;}

        
        public DateTime? MeasurementDate_GT {get; set;}
        
        public DateTime? MeasurementDate_GTE {get; set;}
        
        public DateTime? MeasurementDate_LT {get; set;}
        
        public DateTime? MeasurementDate_LTE {get; set;}
        
        public DateTime? MeasurementDate_EQ {get; set;}

        
        public int? VehicleId_GT {get; set;}
        
        public int? VehicleId_GTE {get; set;}
        
        public int? VehicleId_LT {get; set;}
        
        public int? VehicleId_LTE {get; set;}
        
        public int? VehicleId_EQ {get; set;}

    }