
    using Microsoft.AspNetCore.Mvc;
    public class VehicleQueryControllerDto
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

        [FromQuery(Name = "VinNumber[eq]")]
        public string? VinNumber_EQ {get; set;}
        [FromQuery(Name = "VinNumber[like]")]
        public string? VinNumber_LIKE {get; set;}

        [FromQuery(Name = "PlateNumber[eq]")]
        public string? PlateNumber_EQ {get; set;}
        [FromQuery(Name = "PlateNumber[like]")]
        public string? PlateNumber_LIKE {get; set;}

        [FromQuery(Name = "VehiclemodelId[gt]")]
        public int? VehiclemodelId_GT {get; set;}
        [FromQuery(Name = "VehiclemodelId[gte]")]
        public int? VehiclemodelId_GTE {get; set;}
        [FromQuery(Name = "VehiclemodelId[lt]")]
        public int? VehiclemodelId_LT {get; set;}
        [FromQuery(Name = "VehiclemodelId[lte]")]
        public int? VehiclemodelId_LTE {get; set;}
        [FromQuery(Name = "VehiclemodelId[eq]")]
        public int? VehiclemodelId_EQ {get; set;}


        [FromQuery(Name = "ReleaseYear[gt]")]
        public short? ReleaseYear_GT {get; set;}
        [FromQuery(Name = "ReleaseYear[gte]")]
        public short? ReleaseYear_GTE {get; set;}
        [FromQuery(Name = "ReleaseYear[lt]")]
        public short? ReleaseYear_LT {get; set;}
        [FromQuery(Name = "ReleaseYear[lte]")]
        public short? ReleaseYear_LTE {get; set;}
        [FromQuery(Name = "ReleaseYear[eq]")]
        public short? ReleaseYear_EQ {get; set;}

        [FromQuery(Name = "RegistrationDate[gt]")]
        public DateTime? RegistrationDate_GT {get; set;}
        [FromQuery(Name = "RegistrationDate[gte]")]
        public DateTime? RegistrationDate_GTE {get; set;}
        [FromQuery(Name = "RegistrationDate[lt]")]
        public DateTime? RegistrationDate_LT {get; set;}
        [FromQuery(Name = "RegistrationDate[lte]")]
        public DateTime? RegistrationDate_LTE {get; set;}
        [FromQuery(Name = "RegistrationDate[eq]")]
        public DateTime? RegistrationDate_EQ {get; set;}

        [FromQuery(Name = "StatusId[gt]")]
        public short? StatusId_GT {get; set;}
        [FromQuery(Name = "StatusId[gte]")]
        public short? StatusId_GTE {get; set;}
        [FromQuery(Name = "StatusId[lt]")]
        public short? StatusId_LT {get; set;}
        [FromQuery(Name = "StatusId[lte]")]
        public short? StatusId_LTE {get; set;}
        [FromQuery(Name = "StatusId[eq]")]
        public short? StatusId_EQ {get; set;}









    }