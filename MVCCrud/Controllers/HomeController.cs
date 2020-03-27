using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using System.Web.Security;

namespace MVCCrud.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public static IEnumerable<User> users = new List<User>() {
            new User{ Id = 1, Username="Ankit", Password="12345"},
            new User{ Id = 2, Username="Akash", Password="12345"}
        };


        public ActionResult Index()
        {
            //throw exception for demo
            //throw new Exception("This is unhandled exception");
            if(Session["username"] != null)
            {
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult AuthenticateUser(User user)
        {
            bool isValidUser = users.Any(u => u.Username == user.Username && u.Password == user.Password);
            if (isValidUser)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["username"] = user.Username.ToString();
                return RedirectToAction("Index", "Employees");
                //return true;
            }
            else
            {
                return View();
                //return false;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}