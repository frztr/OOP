namespace Role.DTO
{
    public class AddDto : IConvertible<Global.Role>, IConvertible<AddDto>
    {
        public string Name { get; set; }

        public Global.Role Convert()
        {
            return new Global.Role()
            {
                Name = Name
            };
        }

        Global.Role IConvertible<Global.Role>.Convert()
        {
            return new Global.Role()
            {
                Name = Name
            };
        }

        AddDto IConvertible<AddDto>.Convert()
        {
            return this;
        }
    }
}