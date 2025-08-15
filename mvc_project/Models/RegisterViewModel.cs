using System.Numerics;

namespace mvc_project.Models
{
    public class RegisterViewModel
    {
        public string Name_surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Allinfo_Model
    {
        public string Namesurname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Para_miktari { get; set; }
        public BigInteger IBAN { get; set; }
       
    }

    public class SendModel()
    {
        public string Sender_Mail { get; set; }
        public BigInteger IBAN { get; set; }
        public int Money { get; set; }
        public string Description { get; set; }
    }
}
