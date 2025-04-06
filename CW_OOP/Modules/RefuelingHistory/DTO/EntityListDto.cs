namespace RefuelingHistory.DTO;

public class EntityListDto
{
    public IEnumerable<EntityDto> Items { get; set; }

    public IEnumerable<OilType.DTO.EntityDto> OilTypes { get; set; }

    public IEnumerable<Driver.DTO.EntityDto> Drivers { get; set; }

    public IEnumerable<Vehicle.DTO.EntityDto> Vehicles { get; set; }
}