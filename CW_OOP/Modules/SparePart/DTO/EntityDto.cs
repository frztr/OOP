using Global;

namespace SparePart.DTO
{
    public class EntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountLeft { get; set; }

        public EntityDto(Global.SparePart entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            CountLeft = entity.CountLeft;
        }
    }
}