namespace RepairConsumedSparePart.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.RepairConsumedSparePart Convert()
        {
            return new Global.RepairConsumedSparePart()
            {
                Name = Name
            };
        }
    }
}