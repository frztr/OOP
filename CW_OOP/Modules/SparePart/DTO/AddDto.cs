namespace SparePart.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public int CountLeft { get; set; }

        public Global.SparePart Convert()
        {
            return new Global.SparePart()
            {
                Name = Name,
                CountLeft = CountLeft
            };
        }
    }
}