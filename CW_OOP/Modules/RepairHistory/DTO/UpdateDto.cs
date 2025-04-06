namespace RepairHistory.DTO
{
    public class UpdateDto
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public void Update(Global.RepairHistory entity)
        {
            if (!String.IsNullOrEmpty(Name)) entity.Name = Name;
        }

    }
}