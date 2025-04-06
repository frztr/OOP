using Global;

namespace RefuelingHistory.DTO
{
    public class EntityDto
    {
        public decimal Volume { get; set; }
        public short OilTypeId { get; set; }
        public long FuelStationTinNumber { get; set; }
        public int VehicleId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public short DriverId { get; set; }

        public EntityDto(Global.RefuelingHistory entity)
        {
            Volume = entity.Volume;
            OilTypeId = entity.OilTypeId;
            FuelStationTinNumber = entity.FuelStationTinNumber;
            VehicleId = entity.VehicleId;
            Price = entity.Price;
            DateTime = entity.DateTime;
            DriverId = entity.DriverId;
        }
    }
}