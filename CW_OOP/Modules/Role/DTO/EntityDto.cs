using Global;

namespace Role.DTO
{
    public class EntityDto : IConvertible<EntityDto>
    {
        public short Id { get; set; }
        public string Name { get; set; }

        // public EntityDto(Global.Role entity)
        // {
        //     Id = entity.Id;
        //     Name = entity.Name;
        // }

        public EntityDto Convert()
        {
            return this;
        }
    }
}