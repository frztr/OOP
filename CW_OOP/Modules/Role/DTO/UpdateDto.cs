namespace Role.DTO
{
    public class UpdateDto
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public void Update(Global.Role role)
        {
            if (String.IsNullOrEmpty(Name)) role.Name = Name;
        }
    }
}