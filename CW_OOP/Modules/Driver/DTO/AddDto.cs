using System.Security.Cryptography;
using System.Text;
using Global;

namespace Driver.DTO
{
    public class AddDto
    {
        public long DriverLicense { get; set; }

        public short Experience { get; set; }

        public string Fio { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Global.Driver Convert()
        {
            return new Global.Driver()
            {
                DriverLicense = DriverLicense,
                Experience = Experience,
                User = new User()
                {
                    Login = Login,
                    Fio = Fio,
                    PasswordHash = System.Convert.ToHexString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Password))),
                    RoleId = 3
                }
            };
        }
    }
}