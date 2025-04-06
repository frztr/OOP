namespace Driver.DTO
{
    public class UpdateDto
    {
        public short Id { get; set; }

        public long? DriverLicense { get; set; }

        public short? Experience { get; set; }

        public void Update(Global.Driver entity)
        {
            if (DriverLicense.HasValue) entity.DriverLicense = DriverLicense.Value;
            if (Experience.HasValue) entity.Experience = Experience.Value;
        }

    }
}