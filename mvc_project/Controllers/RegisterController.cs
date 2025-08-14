using Microsoft.AspNetCore.Mvc;
using mvc_project.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace mvc_project.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult register_page()
        {
            return View();
        }


        





//         // Model validasyonu (Gerekli alanlar boş mu, email formatı doğru mu vb.)
//            if (ModelState.IsValid)
//            {
//                // Burada gerçek giriş doğrulama işlemlerini yapın
//                // (örneğin, veritabanından kullanıcıyı sorgulama)

//                // Örnek doğrulama mantığı:
//                if (model.Email == "test@test.com" && model.Password == "12345")
//                {
//                    // Giriş başarılı, kullanıcıyı anasayfaya yönlendir
//                    // Authentication işlemleri burada yapılır
//                    return RedirectToAction("Index", "Home");
//    }
//                else
//                {
//                    // Giriş başarısız, view'a hata mesajı gönder
//                    ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
//                    return View(model);
//}
//            }

//            // Model geçerli değilse, hata mesajlarıyla birlikte view'ı tekrar göster
//            return View(model);









        // POST isteği ile formdan gelen verileri alır
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF saldırılarına karşı koruma sağlar
        public IActionResult Add_user( RegisterViewModel model)
        {

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=bankdb;user=root;password=12345678;"))
            {
                using (MySqlCommand cmd = new MySqlCommand("Add_user", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name_surname", model.Name_surname);
                    cmd.Parameters.AddWithValue("@passsword", model.Password);
                    cmd.Parameters.AddWithValue("@email", model.Email);


                    conn.Open();

                    int effected = cmd.ExecuteNonQuery();

                    return (effected == 0)? BadRequest("islem basarisiz") : View("~/Views/Login/login_page.cshtml");


                }
            }

        }


    }
}
