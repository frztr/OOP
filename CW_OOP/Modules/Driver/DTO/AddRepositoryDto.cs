namespace Driver.DTO
{
    public class AddRepositoryDto
    {
        public short UserId { get; set; }
        public short Experience { get; set; }
        public long DriverLicense { get; set; }
        public Global.Driver Convert()
        {
            return new Global.Driver()
            {
                Experience = Experience,
                DriverLicense = DriverLicense,
                UserId = UserId
            };
        }
    }
}