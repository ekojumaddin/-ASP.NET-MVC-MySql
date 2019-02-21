using MySqlTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySqlTesting.Controllers
{
    public class LoginController : Controller
    {
        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(MySqlTesting.Models.Login login)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var userDetails = context.Logins.Where(x => x.Username == login.Username && x.Password == login.Password).SingleOrDefault();
                if(userDetails == null)
                {
                    login.LoginErrorMessage = "wrong username or password";
                    return View("Index", login);
                }
                else
                {
                    Session["Id"] = userDetails.Id;
                    //return RedirectToAction("Index", "Suppliers");
                }
            }
                return View();
        }
    }
}