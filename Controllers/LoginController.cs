using MoneyTransfer.Helpers;
using MoneyTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransfer.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (!HelpersUI.CheckUserPassword(viewModel.UserName, viewModel.Password))
            {
                ViewBag.Message = "Credentials are wrong !";
                return View(viewModel);
            }

            Session["userName"] = viewModel.UserName;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            if (Session["userName"] != null)
                Session["userName"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}