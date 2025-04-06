using System.Security.Cryptography;
using System.Text;

namespace User.DTO
{
    public class AddDto
    {
        public string Login { get; set; }
        public string Fio { get; set; }
        public string Password { get; set; }

        public short RoleId { get; set; }

        public Global.User Convert()
        {
            return new Global.User()
            {
                Login = Login,
                Fio = Fio,
                PasswordHash = System.Convert.ToHexString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Password))),
                RoleId = RoleId
            };
        }
    }
}