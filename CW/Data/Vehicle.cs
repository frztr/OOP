namespace Global;
public class Vehicle
{
    public int Id { get; set; }
    public string VinNumber { get; set; }
    public string PlateNumber { get; set; }
    public int VehicleModelId { get; set; }
    public short ReleaseYear { get; set; }
    public DateTime RegistrationDate { get; set; }
    public short StatusId { get; set; }
    
    public VehicleModel VehicleModel { get; set; }
    public VehicleStatus VehicleStatus { get; set; }
    public ICollection<VehiclePhoto> Photos { get; set; }
    public ICollection<FuelMeasurementHistory> FuelMeasurements { get; set; }
    public ICollection<MileageMeasurementHistory> MileageMeasurements { get; set; }
    public ICollection<RepairHistory> Repairs { get; set; }
    public ICollection<MaintenanceHistory> Maintenances { get; set; }
    public ICollection<PlannedMaintenanceSchedule> PlannedMaintenances { get; set; }
    public ICollection<VehicleDocument> Documents { get; set; }
    public ICollection<RefuelingHistory> Refuelings { get; set; }
}