namespace OilType.DTO
{
    public class UpdateDto
    {
        public short Id { get; set; }

        public string? Name { get; set; }

        public short? FuelTypeId { get; set; }

        public void Update(Global.OilType entity)
        {
            if (!String.IsNullOrEmpty(Name)) entity.Name = Name;
            if(FuelTypeId.HasValue) entity.FuelTypeId = FuelTypeId.Value;
        }

    }
}