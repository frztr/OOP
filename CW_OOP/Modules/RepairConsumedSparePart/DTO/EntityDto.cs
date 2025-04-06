using Global;

namespace RepairConsumedSparePart.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.RepairConsumedSparePart entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}