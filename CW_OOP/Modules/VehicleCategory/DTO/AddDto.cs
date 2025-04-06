namespace VehicleCategory.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.VehicleCategory Convert()
        {
            return new Global.VehicleCategory()
            {
                Name = Name
            };
        }
    }
}