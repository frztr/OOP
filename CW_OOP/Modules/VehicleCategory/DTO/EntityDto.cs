using Global;

namespace VehicleCategory.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.VehicleCategory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}