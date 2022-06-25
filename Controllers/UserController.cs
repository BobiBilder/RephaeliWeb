using MasterProject.BLL;
using MasterProject.ViewModels;
using MasterProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ViewLoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string IDnum, string userPass, bool isWorker)
        {
            UserBLL userBLL = new UserBLL();
            LoginUser user = userBLL.UsersLogin(IDnum, userPass, isWorker);
            if (user != null)
            {
                Session["User"] = user;
                return RedirectToAction("HomePage", "Home");
            }
            TempData["message"] = "אירעה שגיאה בהתחברות";
            return RedirectToAction("HomePage", "Home");
        }

        [HttpPost]
        public ActionResult Register(Clients client)
        {
            ClientBLL clientBLL = new ClientBLL();
            if (clientBLL.Register(client))
            {
                TempData["message"] = "ההרשמה נעשתה בהצלחה";
                return RedirectToAction("HomePage", "Home");
            }
            TempData["message"] = "אירעה שגיאה בהרשמה";
            return RedirectToAction("Wanted", "Wanted");
        }


        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("HomePage", "Home");
        }
    }
}