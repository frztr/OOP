namespace VehicleDocument.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.VehicleDocument Convert()
        {
            return new Global.VehicleDocument()
            {
                Name = Name
            };
        }
    }
}