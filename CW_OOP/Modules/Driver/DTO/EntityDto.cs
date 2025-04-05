using Global;
using Newtonsoft.Json;

namespace Driver.DTO
{
    public class EntityDto
    {
        public short Id { get; set; }
        public string Fio { get; set; }
        public long DriverLicense { get; set; }
        public short Experience { get; set; }
        public EntityDto(Global.Driver entity)
        {
            Id = entity.Id;
            Fio = entity.User.Fio;
            DriverLicense = entity.DriverLicense;
            Experience = entity.Experience;
        }
    }
}