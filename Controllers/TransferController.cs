using MoneyTransfer.DataLayer.API;
using MoneyTransfer.Helpers;
using MoneyTransfer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransfer.Controllers
{
    public class TransferController : Controller
    {
        // GET: Transfer
        public ActionResult Index()
        {
            if (Session["userName"] == null)
                return RedirectToAction("Index", "Login");

            Transfer viewModel = new Transfer();

            viewModel.Currencies = HelpersUI.GetCurrencies();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(Transfer viewModel)
        {
            if (Session["userName"] == null)
                return RedirectToAction("Index", "Login");

            if (!ModelState.IsValid)
            {
                viewModel.Currencies = HelpersUI.GetCurrencies();

                return View(viewModel);
            }

            string userName = Session["userName"].ToString();
            int offesetDate = int.Parse(System.Configuration.ConfigurationManager.AppSettings["AfterValueDaysWillExpireToken"]);
            int CurrencyId = int.Parse(viewModel.Currency);
            int DestinationCurrencyId = int.Parse(viewModel.DestinationCurrency);

            if (HelpersUI.AddTransaction(userName, offesetDate, viewModel.CNP, viewModel.IBAN, viewModel.Amount, CurrencyId, viewModel.DestinationAmount, DestinationCurrencyId))
                return RedirectToAction("Index", "Home");

            return Content("Failed");
        }

        [HttpPost]
        public ActionResult updateValue(decimal inputAmount, int selectCurrency, int selectDestinationCurrency, string inputIBAN)
        {
            string selectCurrencyStr = HelpersUI.GetCurrencyById(selectCurrency).Trim();
            string selectDestinationCurrencyStr = HelpersUI.GetCurrencyById(selectDestinationCurrency).Trim();

            var beforeTaxesAmount = inputAmount.ConvertTo(selectCurrencyStr, "EUR");

            var defaultTax = Decimal.Parse(System.Configuration.ConfigurationManager.AppSettings["DefaultValuePerTransaction"]);
            var defaultValueForEveryThousand = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DefaultValueForEveryThousand"]);
            var TaxForEveryThousand = Decimal.ToInt32(beforeTaxesAmount) / 1000 * defaultValueForEveryThousand;

            beforeTaxesAmount -= defaultTax;
            beforeTaxesAmount -= Convert.ToDecimal(TaxForEveryThousand);

            if (!string.IsNullOrEmpty(inputIBAN))
            {
                if (CheckIBAN.Instance.Check(inputIBAN))
                {
                    var Abbr = inputIBAN.Substring(0, 2);
                    if (!HelpersUI.CheckCountry(Abbr))
                    {
                        var Commision = Decimal.Parse(System.Configuration.ConfigurationManager.AppSettings["CommisionIfYouAreNotInEU"]) / 100m;
                        beforeTaxesAmount -= beforeTaxesAmount * Commision;
                    }
                }
            }

            var afterTaxesAmount = beforeTaxesAmount.ConvertTo("EUR", selectDestinationCurrencyStr);

            if (afterTaxesAmount < 0)
                afterTaxesAmount = 0;

            afterTaxesAmount = Decimal.Round(afterTaxesAmount, 3, MidpointRounding.AwayFromZero);

            JsonResult result = new JsonResult();
            result = this.Json(JsonConvert.SerializeObject(afterTaxesAmount)); 
            return result;
        }
    }
}