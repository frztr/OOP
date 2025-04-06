using System.ComponentModel.DataAnnotations;

namespace FuelType.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.FuelType Convert()
        {
            return new Global.FuelType()
            {
                Name = Name
            };
        }
    }
}