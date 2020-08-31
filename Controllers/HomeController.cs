using MoneyTransfer.Helpers;
using MoneyTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransfer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["userName"] == null)
                return RedirectToAction("Index", "Login");

            var list = HelpersUI.GetTransactionsByUserName(Session["userName"].ToString());

            return View(list);
        }

        public ActionResult NewToken(int id)
        {
            var offset = int.Parse(System.Configuration.ConfigurationManager.AppSettings["AfterValueDaysWillExpireToken"]);

            HelpersUI.RenewToken(id, offset);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangeStatus(int id)
        {
            HelpersUI.ChangeStatus(id);
            return RedirectToAction("Index", "Home");
        }
    }
}