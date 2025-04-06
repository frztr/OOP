namespace FuelMeasurementHistory.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.FuelMeasurementHistory Convert()
        {
            return new Global.FuelMeasurementHistory()
            {
                Name = Name
            };
        }
    }
}