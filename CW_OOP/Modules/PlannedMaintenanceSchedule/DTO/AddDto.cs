namespace PlannedMaintenanceSchedule.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.PlannedMaintenanceSchedule Convert()
        {
            return new Global.PlannedMaintenanceSchedule()
            {
                Name = Name
            };
        }
    }
}