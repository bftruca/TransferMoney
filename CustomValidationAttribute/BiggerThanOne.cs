using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTransfer.CustomValidationAttribute
{
    public class BiggerThanOne : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            if (Convert.ToDecimal(value) > 1)
                return true;

            return false;
        }
    }
}