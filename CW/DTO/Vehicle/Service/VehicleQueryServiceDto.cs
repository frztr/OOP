
    using Microsoft.AspNetCore.Mvc;
    public class VehicleQueryServiceDto
    {
        public int Count { get; set; } = 50;

        public int Offset { get; set; } = 0;
        
        
        public int? Id_GT {get; set;}
        
        public int? Id_GTE {get; set;}
        
        public int? Id_LT {get; set;}
        
        public int? Id_LTE {get; set;}
        
        public int? Id_EQ {get; set;}

        
        public string? VinNumber_EQ {get; set;}
        
        public string? VinNumber_LIKE {get; set;}

        
        public string? PlateNumber_EQ {get; set;}
        
        public string? PlateNumber_LIKE {get; set;}

        
        public int? VehiclemodelId_GT {get; set;}
        
        public int? VehiclemodelId_GTE {get; set;}
        
        public int? VehiclemodelId_LT {get; set;}
        
        public int? VehiclemodelId_LTE {get; set;}
        
        public int? VehiclemodelId_EQ {get; set;}


        
        public short? ReleaseYear_GT {get; set;}
        
        public short? ReleaseYear_GTE {get; set;}
        
        public short? ReleaseYear_LT {get; set;}
        
        public short? ReleaseYear_LTE {get; set;}
        
        public short? ReleaseYear_EQ {get; set;}

        
        public DateTime? RegistrationDate_GT {get; set;}
        
        public DateTime? RegistrationDate_GTE {get; set;}
        
        public DateTime? RegistrationDate_LT {get; set;}
        
        public DateTime? RegistrationDate_LTE {get; set;}
        
        public DateTime? RegistrationDate_EQ {get; set;}

        
        public short? StatusId_GT {get; set;}
        
        public short? StatusId_GTE {get; set;}
        
        public short? StatusId_LT {get; set;}
        
        public short? StatusId_LTE {get; set;}
        
        public short? StatusId_EQ {get; set;}









    }