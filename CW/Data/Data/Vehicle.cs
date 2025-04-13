using System.ComponentModel.DataAnnotations;
public class Vehicle{
    [Required]
	public int Id { get;set; }
	[StringLength(17)]
	public string VinNumber { get;set; }
	[StringLength(15)]
	public string PlateNumber { get;set; }
	public int VehiclemodelId { get;set; }
	public VehicleModel VehicleModel {get;set;}
	public short ReleaseYear { get;set; }
	public DateTime RegistrationDate { get;set; }
	public short StatusId { get;set; }
	public VehicleStatus VehicleStatus {get;set;}
	public ICollection<VehiclePhoto> VehiclePhotos { get;set; }
	public ICollection<FuelMeasurementHistory> FuelMeasurementHistories { get;set; }
	public ICollection<MileageMeasurementHistory> MileageMeasurementHistories { get;set; }
	public ICollection<RepairHistory> RepairHistories { get;set; }
	public ICollection<RefuelingHistory> RefuelingHistories { get;set; }
	public ICollection<MaintenanceHistory> MaintenanceHistories { get;set; }
	public ICollection<PlannedMaintenanceSchedule> PlannedMaintenanceSchedules { get;set; }
	public ICollection<VehicleDocument> VehicleDocuments { get;set; }
}