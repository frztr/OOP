using Global;

namespace Driver.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public long DriverLicense { get; set; }

        public short Experience { get; set; }

        public EntityDto(Global.Driver entity)
        {
            Id = entity.Id;
            DriverLicense = entity.DriverLicense;
            Experience = entity.Experience;
        }
    }
}