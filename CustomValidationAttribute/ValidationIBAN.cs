using MoneyTransfer.DataLayer.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTransfer.CustomValidationAttribute
{
    public class ValidationIBAN : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            return CheckIBAN.Instance.Check(value.ToString());
        }
    }
}