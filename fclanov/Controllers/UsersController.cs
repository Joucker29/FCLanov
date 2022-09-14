using fclanov.Data;
using fclanov.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fclanov.Controllers
{
    public class UsersController : Controller
    {
        FclanovData Databaze { get; }

        public UsersController(FclanovData databaze)
        {
            Databaze = databaze;
        }
        public IActionResult registrovani()
        {
            return View();
        }
        public IActionResult prihlaseni()
        {
            return View();
        }
        [HttpPost]
        public IActionResult registrovani(string jmeno, string heslo, string email)
        {
            if (jmeno == null)
            {
                ViewData["chyba"] = "Nenapsali jste jméno!";
                return View();
            }
            if (email == null)
            {
                ViewData["chyba"] = "Nenapsali jste E-mail!";
                return View();
            }
            if (heslo == null)
            {
                ViewData["chyba"] = "Nenapsali jste Heslo!";
                return View();
            }
            Users SameUser = Databaze.Users
            .Where(n => n.Jmeno == jmeno)
            .FirstOrDefault();


            Users SameMail = Databaze.Users
            .Where(u => u.Mail == email)
            .FirstOrDefault();

            if (SameUser == null && SameMail == null)
            {
                Users newUser = new Users()
                {
                    Jmeno = jmeno,
                    Mail = email,
                    Heslo_hashed = BCrypt.Net.BCrypt.HashPassword(heslo)
                };
                Databaze.Add(newUser);
                Databaze.SaveChanges();
                return RedirectToAction("prihlaseni", "Users");
            }

            if (SameUser != null)
            {
                ViewData["chyba"] = "Tento uživatel již existuje";
            }

            if (SameMail != null)
            {
                ViewData["chyba"] = "Tento E-mail již existuje";
            }
            return View();
        }
        [HttpPost]
        public IActionResult prihlaseni(string jmeno, string heslo)
        {

            if (jmeno == null)
            {
                ViewData["chyba"] = "Nenapsali jste jméno!";
                return View();
            }
            if (heslo == null)
            {
                ViewData["chyba"] = "Nenapsali jste Heslo!";
                return View();
            }

            Users SameUser = Databaze.Users
            .Where(n => n.Jmeno == jmeno)
            .FirstOrDefault();

            if (SameUser != null && BCrypt.Net.BCrypt.Verify(heslo, SameUser.Heslo_hashed))
            {
                HttpContext.Session.SetString("Jmeno_Prihlaseni", jmeno);
                return RedirectToAction("prehled", "Poznamkyy");
            }
            else
            {
                ViewData["chyba"] = "Špatné jméno nebo heslo.";
            }

            return View();
        }

    }
}
