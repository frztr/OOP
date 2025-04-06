namespace VehicleModel.DTO
{
    public class UpdateDto
    {
        public short Id { get; set; }

        public string? Name { get; set; }

        public short? ManufacturerId { get; set; }

        public short? VehicleCategoryId { get; set; }

        public short? Power { get; set; }

        public short? FuelTypeId { get; set; }

        public int? LoadCapacity { get; set; }

        public void Update(Global.VehicleModel entity)
        {
            if (!String.IsNullOrEmpty(Name)) entity.Name = Name;
            if (ManufacturerId.HasValue) entity.ManufacturerId = ManufacturerId.Value;
            if (VehicleCategoryId.HasValue) entity.VehicleCategoryId = VehicleCategoryId.Value;
            if (Power.HasValue) entity.Power = Power.Value;
            if (FuelTypeId.HasValue) entity.FuelTypeId = FuelTypeId.Value;
            if (LoadCapacity.HasValue) entity.LoadCapacity = LoadCapacity.Value;
        }

    }
}