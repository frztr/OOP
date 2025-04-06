using Global;

namespace VehiclePhoto.DTO
{
    public class EntityDto
    {
        public int Id { get; set; }
        public string Src { get; set; }

        public EntityDto(Global.VehiclePhoto entity)
        {
            Id = entity.Id;
            Src = entity.Src;
        }
    }
}