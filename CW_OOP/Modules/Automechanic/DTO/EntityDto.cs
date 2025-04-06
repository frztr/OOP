using Global;

namespace Automechanic.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Fio { get; set; }
        public EntityDto(Global.Automechanic entity)
        {
            Id = entity.Id;
            Fio = entity.User.Fio;
        }
    }
}