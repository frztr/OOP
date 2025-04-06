namespace VehicleStatus.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.VehicleStatus Convert()
        {
            return new Global.VehicleStatus()
            {
                Name = Name
            };
        }
    }
}