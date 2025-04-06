using Global;

namespace OilType.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.OilType entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}