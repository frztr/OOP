namespace Role.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.Role Convert()
        {
            return new Global.Role()
            {
                Name = Name
            };
        }
    }
}