namespace Automechanic.DTO
{
    public class UpdateDto
    {
        public short Id { get; set; }

        public string Qualification { get; set; }

        public void Update(Global.Automechanic entity)
        {
            if (!String.IsNullOrEmpty(Qualification)) entity.Qualification = Qualification;
        }

    }
}