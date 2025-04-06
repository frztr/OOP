using Global;

namespace FuelType.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.FuelType entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}