using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTransfer.Models
{
    public class Transaction : Transfer
    {
        [DataType(DataType.Text)]
        public string Status { get; set; }

        [DataType(DataType.Text)]
        public string Token { get; set; }

        public string User { get; set; }
    }
}