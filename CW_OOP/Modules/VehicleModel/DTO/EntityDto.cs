using Global;

namespace VehicleModel.DTO
{
    public class EntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short ManufacturerId { get; set; }
        public short VehicleCategoryId { get; set; }
        public short Power { get; set; }
        public short FuelTypeId { get; set; }
        public int LoadCapacity { get; set; }

        public EntityDto(Global.VehicleModel entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            ManufacturerId = entity.ManufacturerId;
            VehicleCategoryId = entity.VehicleCategoryId;
            Power = entity.Power;
            FuelTypeId = entity.FuelTypeId;
            LoadCapacity = entity.LoadCapacity;
        }
    }
}