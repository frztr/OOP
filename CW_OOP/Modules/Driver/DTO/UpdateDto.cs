using System.Security.Cryptography;
using System.Text;

namespace Driver.DTO
{
    public class UpdateDto
    {
        public short Id { get; set; }
        public long? DriverLicense { get; set; }

        public short? Experience { get; set; }

        public string Fio { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public void Update(Global.Driver entity)
        {
            if (DriverLicense.HasValue) entity.DriverLicense = DriverLicense.Value;
            if (Experience.HasValue) entity.Experience = Experience.Value;
            if (!String.IsNullOrEmpty(Fio)) entity.User.Fio = Fio;
            if (!String.IsNullOrEmpty(Login)) entity.User.Login = Login;
            if (!String.IsNullOrEmpty(Password)) entity.User.PasswordHash = System.Convert.ToHexString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Password)));
        }
    }
}