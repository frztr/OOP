namespace MaintenanceHistory.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.MaintenanceHistory Convert()
        {
            return new Global.MaintenanceHistory()
            {
                Name = Name
            };
        }
    }
}