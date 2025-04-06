using Global;

namespace MileageMeasurementHistory.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.MileageMeasurementHistory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}