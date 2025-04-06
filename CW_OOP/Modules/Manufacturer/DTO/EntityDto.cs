using Global;

namespace Manufacturer.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.Manufacturer entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}