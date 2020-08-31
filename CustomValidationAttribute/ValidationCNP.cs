using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTransfer.CustomValidationAttribute
{
    public class ValidationCNP : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string CNP = value.ToString();
            string hash = "279146358279";
            int hashResult = 0;

            // CNP must have 13 characters
            if (CNP.Length != 13)
                return false;



            for (int i = 0; i < CNP.Length; i++)
            {
                if (!Char.IsDigit(CNP[i]))
                    return false;

                if (i < 12)
                {
                    hashResult += int.Parse(CNP[i].ToString()) * int.Parse(hash[i].ToString());
                }
            }

            hashResult %= 11;
            if (hashResult == 10)
                hashResult = 1;

            int year = int.Parse(CNP[1].ToString()) * 10 + int.Parse(CNP[2].ToString());

            switch(CNP[0])
            {
                case '1':
                case '2':
                    year += 1900;
                    break;
                case '3':
                case '4':
                    year += 1800;
                    break;
                case '5':
                case '6':
                    year += 2000;
                    break;
                case '7':
                case '8':
                case '9':
                    year += 2000;
                    if (year > (DateTime.Now.Year - 14))
                        year -= 100;
                    break;
                default:
                    return false;
            }

            return (year > 1800 && year < 2099 && int.Parse(CNP[12].ToString()) == hashResult);
        }
    }
}