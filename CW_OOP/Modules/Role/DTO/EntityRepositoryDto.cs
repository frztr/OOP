using Global;

namespace Role.DTO
{
    public class EntityRepositoryDto : IConvertible<EntityRepositoryDto>
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public EntityRepositoryDto Convert()
        {
            return this;
        }
    }
}