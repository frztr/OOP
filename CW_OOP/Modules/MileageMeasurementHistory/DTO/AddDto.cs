namespace MileageMeasurementHistory.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.MileageMeasurementHistory Convert()
        {
            return new Global.MileageMeasurementHistory()
            {
                Name = Name
            };
        }
    }
}