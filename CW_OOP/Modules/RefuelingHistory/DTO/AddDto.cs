namespace RefuelingHistory.DTO
{
    public class AddDto
    {
        public decimal Volume { get; set; }
        public short OilTypeId { get; set; }
        public long FuelStationTinNumber { get; set; }
        public int VehicleId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public short DriverId { get; set; }

        public Global.RefuelingHistory Convert()
        {
            return new Global.RefuelingHistory()
            {
                Volume = Volume,
                OilTypeId = OilTypeId,
                FuelStationTinNumber = FuelStationTinNumber,
                VehicleId = VehicleId,
                Price = Price,
                DateTime = DateTime,
                DriverId = DriverId
            };
        }
    }
}