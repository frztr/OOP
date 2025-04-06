namespace SparePart.DTO
{
    public class UpdateDto
    {
        public short Id { get; set; }

        public string Name { get; set; }
        public int? CountLeft { get; set; }

        public void Update(Global.SparePart entity)
        {
            if (!String.IsNullOrEmpty(Name)) entity.Name = Name;
            if (CountLeft.HasValue) entity.CountLeft = CountLeft.Value;
        }

    }
}