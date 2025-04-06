namespace DocumentType.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.DocumentType Convert()
        {
            return new Global.DocumentType()
            {
                Name = Name
            };
        }
    }
}