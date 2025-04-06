namespace VehicleModel.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public short ManufacturerId { get; set; }

        public short VehicleCategoryId { get; set; }

        public short Power { get; set; }

        public short FuelTypeId { get; set; }

        public int LoadCapacity { get; set; }

        public Global.VehicleModel Convert()
        {
            return new Global.VehicleModel()
            {
                Name = Name,
                ManufacturerId = ManufacturerId,
                VehicleCategoryId = VehicleCategoryId,
                Power = Power,
                FuelTypeId = FuelTypeId,
                LoadCapacity = LoadCapacity
            };
        }
    }
}