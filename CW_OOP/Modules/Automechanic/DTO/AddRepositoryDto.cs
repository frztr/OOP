using System.Security.Cryptography;
using System.Text;

namespace Automechanic.DTO
{
    public class AddRepositoryDto
    {
        public short UserId { get; set; }
        public string Qualification { get; set; }

        public Global.Automechanic Convert()
        {
            return new Global.Automechanic()
            {
                Qualification = Qualification,
                UserId = UserId
            };
        }
    }
}