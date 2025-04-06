using Global;

namespace FuelMeasurementHistory.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.FuelMeasurementHistory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}