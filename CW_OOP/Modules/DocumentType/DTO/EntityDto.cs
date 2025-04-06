using Global;

namespace DocumentType.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.DocumentType entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}