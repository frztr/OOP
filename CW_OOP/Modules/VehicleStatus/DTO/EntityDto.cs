using Global;

namespace VehicleStatus.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.VehicleStatus entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}