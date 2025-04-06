namespace Vehicle.DTO
{
    public class UpdateDto
    {
        public int Id { get; set; }
        public string? VinNumber { get; set; }
        public string? PlateNumber { get; set; }
        public int? VehicleModelId { get; set; }
        public short? ReleaseYear { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public short? StatusId { get; set; }

        public void Update(Global.Vehicle entity)
        {
            if (!String.IsNullOrEmpty(VinNumber)) entity.VinNumber = VinNumber;
            if (!String.IsNullOrEmpty(PlateNumber)) entity.PlateNumber = PlateNumber;
            if (VehicleModelId.HasValue) entity.VehicleModelId = VehicleModelId.Value;
            if (ReleaseYear.HasValue) entity.ReleaseYear = ReleaseYear.Value;
            if (RegistrationDate.HasValue) entity.RegistrationDate = RegistrationDate.Value;
            if (StatusId.HasValue) entity.StatusId = StatusId.Value;
        }

    }
}