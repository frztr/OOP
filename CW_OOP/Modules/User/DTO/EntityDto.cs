using Global;

namespace User.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public EntityDto(Global.User entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }
    }
}