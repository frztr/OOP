using Global;

namespace RepairHistory.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.RepairHistory entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}