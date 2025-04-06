namespace MaintenanceType.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.MaintenanceType Convert()
        {
            return new Global.MaintenanceType()
            {
                Name = Name
            };
        }
    }
}