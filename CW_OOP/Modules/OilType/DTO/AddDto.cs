namespace OilType.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public short FuelTypeId { get; set; }

        public Global.OilType Convert()
        {
            return new Global.OilType()
            {
                Name = Name,
                FuelTypeId = FuelTypeId
            };
        }
    }
}