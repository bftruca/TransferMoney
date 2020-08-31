using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTransfer.DataLayer.API.Models
{
    public class BankData
    {
        public string bankCode { get; set; }
        public string name { get; set; }
    }

    public class CheckResults
    {
    }

    public class IBAN
    {
        public bool valid { get; set; }
        public List<object> messages { get; set; }
        public string iban { get; set; }
        public BankData bankData { get; set; }
        public CheckResults checkResults { get; set; }
    }
}