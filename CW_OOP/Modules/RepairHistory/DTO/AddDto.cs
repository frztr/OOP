namespace RepairHistory.DTO
{
    public class AddDto
    {
        public string Name { get; set; }

        public Global.RepairHistory Convert()
        {
            return new Global.RepairHistory()
            {
                Name = Name
            };
        }
    }
}