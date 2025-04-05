namespace Role.DTO
{
    public class UpdateDto : IConvertible<UpdateDto>, IUpdateDto<short,Global.Role>
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public UpdateDto Convert()
        {
            return this;
        }

        public void Update(Global.Role entity)
        {
            if (!String.IsNullOrEmpty(Name)) entity.Name = Name;
        }
    }
}