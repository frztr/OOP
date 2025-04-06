using Global;

namespace MaintenanceType.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.MaintenanceType entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}