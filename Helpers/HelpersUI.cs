using Microsoft.Ajax.Utilities;
using MoneyTransfer.DataLayer;
using MoneyTransfer.DataLayer.API;
using MoneyTransfer.DataLayer.API.Models;
using MoneyTransfer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransfer.Helpers
{
    public static class HelpersUI
    {
        public static List<SelectListItem> GetCurrencies()
        {
            var list = new List<SelectListItem>();

            var dt = Data.Instance.GetCurrencies();

            foreach (DataRow row in dt.Rows)
            {
                var elem = new SelectListItem();
                elem.Value = row.ItemArray[0].ToString();
                elem.Text = row.ItemArray[1].ToString();
                list.Add(elem);
            }

            return list;
        }

        public static string GetCurrencyById(int id)
        {
            var dt = Data.Instance.GetCurrencyById(id);
            var value = string.Empty;

            foreach (DataRow row in dt.Rows)
            {
                value = row.ItemArray[0].ToString();
            }

            return value;
        }

        public static decimal ConvertTo(this decimal amount, string from, string to)
        {
            var _Exchanges = Exchange.Instance.GetCurrencies();

            var fromValue = _Exchanges.getCurrency(from);
            var toValue = _Exchanges.getCurrency(to);

            if (!from.Equals(_Exchanges.Base))
                amount /= Convert.ToDecimal(fromValue);

            if (!to.Equals(_Exchanges.Base))
                amount *= Convert.ToDecimal(toValue);

            return amount;
        }

        public static bool CheckUserPassword(string userName, string password)
        {
            var hashPassword = String.Empty;
            var dt = Data.Instance.GetUserPassword(userName);
            foreach (DataRow row in dt.Rows)
            {
                hashPassword = row.ItemArray[0].ToString();
            }

            if (String.IsNullOrEmpty(hashPassword))
                return false;

            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }

        public static IEnumerable<Transaction> GetTransactionsByCNPAndToken(string CNP, string Token, out string error)
        {
            error = string.Empty;

            var list = new List<Transaction>();
                        
            var dt = Data.Instance.GetTransactionsByCNPAndToken(CNP, Token);

            if (dt.Rows.Count == 1 && dt.Columns.Count == 1)
            {
                error = "Token is expired!";
                return list;
            }
                
            if (dt.Rows.Count == 0)
            {
                error = "CNP/Token is wrong!";
                return list;
            }
                
            foreach (DataRow row in dt.Rows)
            {
                var elem = new Transaction();
                elem.TransferId = Int32.Parse(row.ItemArray[0].ToString());
                elem.User = row.ItemArray[1].ToString();
                elem.Token = row.ItemArray[2].ToString();
                elem.IBAN = row.ItemArray[3].ToString();
                elem.Amount = Decimal.Parse(row.ItemArray[4].ToString());
                elem.Currency = row.ItemArray[5].ToString();
                elem.DestinationAmount = Decimal.Parse(row.ItemArray[6].ToString());
                elem.DestinationCurrency = row.ItemArray[7].ToString();
                elem.Status = row.ItemArray[8].ToString();
                elem.CNP = row.ItemArray[9].ToString();
                list.Add(elem);
            }

            return list;
        }

        public static IEnumerable<Transaction> GetTransactionsByUserName(string userName)
        {
            var list = new List<Transaction>();

            var dt = Data.Instance.GetTransactionsByUserName(userName);

            foreach (DataRow row in dt.Rows)
            {
                var elem = new Transaction();
                elem.TransferId = Int32.Parse(row.ItemArray[0].ToString());
                elem.User = row.ItemArray[1].ToString();
                elem.Token = row.ItemArray[2].ToString();
                elem.IBAN = row.ItemArray[3].ToString();
                elem.Amount = Decimal.Parse(row.ItemArray[4].ToString());
                elem.Currency = row.ItemArray[5].ToString();
                elem.DestinationAmount = Decimal.Parse(row.ItemArray[6].ToString());
                elem.DestinationCurrency = row.ItemArray[7].ToString();
                elem.Status = row.ItemArray[8].ToString();
                elem.CNP = row.ItemArray[9].ToString();
                list.Add(elem);
            }

            return list;
        }

        public static bool RenewToken(int id, int offset)
        {
            return Data.Instance.RenewToken(id, offset);
        }

        public static bool ChangeStatus(int id)
        {
            return Data.Instance.ChangeStatus(id);
        }

        public static bool AddTransaction(string userName, int offsetDate, string CNP, string IBAN, decimal Amount, int CurrencyId, decimal AmountReceived, int CurrencyReceived_Id)
        {
            return Data.Instance.AddTransaction(userName, offsetDate, CNP, IBAN, Amount, CurrencyId, AmountReceived, CurrencyReceived_Id);
        }

        public static bool CheckCountry(string Abbr)
        {
            var dt = Data.Instance.CheckCountry(Abbr);
            var value = false;

            foreach (DataRow row in dt.Rows)
            {
                value = Convert.ToBoolean(int.Parse(row.ItemArray[0].ToString()));
            }

            return value;
        }
    }
}