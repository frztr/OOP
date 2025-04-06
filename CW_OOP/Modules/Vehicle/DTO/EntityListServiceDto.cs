using Vehicle.DTO;

namespace Vehicle;
public class EntityListServiceDto : EntityListDto
{
    public VehicleModel.DTO.EntityListDto vehicleModels { get; set; }

    public IEnumerable<VehicleStatus.DTO.EntityDto> vehicleStatuses { get; set; }
}