using Global;

namespace PlannedMaintenanceSchedule.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.PlannedMaintenanceSchedule entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}