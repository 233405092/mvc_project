using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using mvc_project.Models;
using MySql.Data.MySqlClient;
using System.Data;
namespace mvc_project.Controllers
{
    public class loginController : Controller
    {
        public IActionResult login_page()
        {
            return View();
        }


        // return RedirectToAction("Index", "Account"); // Hesap sayfasına yönlendirme

        // POST isteği ile formdan gelen verileri alır
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF saldırılarına karşı koruma sağlar
        public IActionResult login_account(LoginModel model)
        {

           
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=bankdb;user=root;password=12345678;"))
            {
                using (MySqlCommand cmd = new MySqlCommand("Get_user_and_account_info", conn))
                { 
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_email", model.Email);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {

                        if (reader.Read()) {
                            // kullanıcının var olduğu ve doğru bilgileri girdiği varsayılır
                            Allinfo_Model bilgiler = new Allinfo_Model(){
                                Namesurname = reader["Name_surname"].ToString(),
                                Password = reader["Passworddd"].ToString(),
                                Email = reader["Email"].ToString(),
                                Para_miktari = Convert.ToInt32(reader["Para_miktarı"]),
                                IBAN = Convert.ToInt64(reader["IBAN"])
                            };

                            return View("~/Views/Account/Account.cshtml", bilgiler);
                        }

                        return View("/Views/Index/Index.cshtml");

                    }
                }
            }


        }




    }
}
