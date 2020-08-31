using MoneyTransfer.CustomValidationAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTransfer.Models
{
    public class CheckTransaction
    {
        [Required]
        [DataType(DataType.Text)]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [ValidationCNP]
        public string CNP { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}