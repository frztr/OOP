using Global;

namespace MaintenanceHistory.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.MaintenanceHistory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}