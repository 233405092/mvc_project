using Microsoft.AspNetCore.Mvc;
using mvc_project.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Numerics;
namespace mvc_project.Controllers
{
    public class SendController : Controller
    {
        public IActionResult Send_page(string Email)
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=bankdb;user=root;password=12345678;"))
            {
                using (MySqlCommand cmd = new MySqlCommand("Get_user_and_account_info", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_email", Email);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            // kullanıcının var olduğu ve doğru bilgileri girdiği varsayılır
                            Allinfo_Model bilgiler = new Allinfo_Model()
                            {
                                Namesurname = reader["Name_surname"].ToString(),
                                Password = reader["Passworddd"].ToString(),
                                Email = reader["Email"].ToString(),
                                Para_miktari = Convert.ToInt32(reader["Para_miktarı"]),
                                IBAN = Convert.ToInt64(reader["IBAN"])
                            };

                            return View("~/Views/Send/Send_page.cshtml", bilgiler);
                        }

                        return View("/Views/Index/Index.cshtml");

                    }
                }
            }


            return View();
        }


        public IActionResult Send_money(SendModel transfer_bilgileri)
        {


            return null;
        }



    }
}
