using VehicleModel.DTO;

public class EntityListServiceDto : EntityListDto
{
    public IEnumerable<Manufacturer.DTO.EntityDto> Manufacturers { get; set; }

    public IEnumerable<VehicleCategory.DTO.EntityDto> VehicleCategories { get; set; }

    public IEnumerable<FuelType.DTO.EntityDto> FuelTypes { get; set; }
}