using Global;

namespace Vehicle.DTO
{
    public class EntityDto
    {
        public int Id { get; set; }
        public string VinNumber { get; set; }
        public string PlateNumber { get; set; }
        public int VehicleModelId { get; set; }
        public short ReleaseYear { get; set; }
        public DateTime RegistrationDate { get; set; }
        public short StatusId { get; set; }

        public EntityDto(Global.Vehicle entity)
        {
            Id = entity.Id;
            VinNumber = entity.VinNumber;
            PlateNumber = entity.PlateNumber;
            VehicleModelId = entity.VehicleModelId;
            ReleaseYear = entity.ReleaseYear;
            RegistrationDate = entity.RegistrationDate;
            StatusId = entity.StatusId;
        }
    }
}