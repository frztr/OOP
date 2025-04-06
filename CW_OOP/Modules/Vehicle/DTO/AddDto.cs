namespace Vehicle.DTO
{
    public class AddDto
    {
        public string VinNumber { get; set; }
        public string PlateNumber { get; set; }
        public int VehicleModelId { get; set; }
        public short ReleaseYear { get; set; }
        public DateTime RegistrationDate { get; set; }
        public short StatusId { get; set; }

        public Global.Vehicle Convert()
        {
            return new Global.Vehicle()
            {
                VinNumber = VinNumber,
                PlateNumber = PlateNumber,
                VehicleModelId = VehicleModelId,
                ReleaseYear = ReleaseYear,
                RegistrationDate = RegistrationDate,
                StatusId = StatusId
            };
        }
    }
}