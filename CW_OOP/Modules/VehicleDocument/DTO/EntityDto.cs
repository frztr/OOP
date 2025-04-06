using Global;

namespace VehicleDocument.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.VehicleDocument entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}