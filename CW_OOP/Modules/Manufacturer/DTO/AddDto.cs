namespace Manufacturer.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.Manufacturer Convert()
        {
            return new Global.Manufacturer()
            {
                Name = Name
            };
        }
    }
}