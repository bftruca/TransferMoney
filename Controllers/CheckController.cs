using MoneyTransfer.Helpers;
using MoneyTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransfer.Controllers
{
    public class CheckController : Controller
    {
        // GET: Check
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CheckTransaction viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            string error;
            viewModel.Transactions = HelpersUI.GetTransactionsByCNPAndToken(viewModel.CNP, viewModel.Token, out error);
            if (!string.IsNullOrEmpty(error))
                ViewBag.Message = error;

            return View(viewModel);
        }
    }
}