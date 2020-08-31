using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTransfer.DataLayer.API.Models
{
    public class Rates
    {
        public double CAD { get; set; }
        public double HKD { get; set; }
        public double ISK { get; set; }
        public double PHP { get; set; }
        public double DKK { get; set; }
        public double HUF { get; set; }
        public double CZK { get; set; }
        public double AUD { get; set; }
        public double RON { get; set; }
        public double SEK { get; set; }
        public double IDR { get; set; }
        public double INR { get; set; }
        public double BRL { get; set; }
        public double RUB { get; set; }
        public double HRK { get; set; }
        public double JPY { get; set; }
        public double THB { get; set; }
        public double CHF { get; set; }
        public double SGD { get; set; }
        public double PLN { get; set; }
        public double BGN { get; set; }
        public double TRY { get; set; }
        public double CNY { get; set; }
        public double NOK { get; set; }
        public double NZD { get; set; }
        public double ZAR { get; set; }
        public double USD { get; set; }
        public double MXN { get; set; }
        public double ILS { get; set; }
        public double GBP { get; set; }
        public double KRW { get; set; }
        public double MYR { get; set; }

        public double getCurrency(string Currency)
        {
            switch (Currency)
            {
                case "CAD":
                    return CAD;

                case "HKD":
                    return HKD;

                case "ISK":
                    return ISK;

                case "PHP":
                    return PHP;

                case "DKK":
                    return DKK;

                case "HUF":
                    return HUF;

                case "CZK":
                    return CZK;

                case "AUD":
                    return AUD;

                case "RON":
                    return RON;

                case "SEK":
                    return SEK;

                case "IDR":
                    return IDR;

                case "INR":
                    return INR;

                case "BRL":
                    return BRL;

                case "RUB":
                    return RUB;

                case "HRK":
                    return HRK;

                case "JPY":
                    return JPY;

                case "THB":
                    return THB;

                case "CHF":
                    return CHF;

                case "SGD":
                    return SGD;

                case "PLN":
                    return PLN;

                case "BGN":
                    return BGN;

                case "TRY":
                    return TRY;

                case "CNY":
                    return CNY;

                case "NOK":
                    return NOK;

                case "NZD":
                    return NZD;

                case "ZAR":
                    return ZAR;

                case "USD":
                    return USD;

                case "MXN":
                    return MXN;

                case "ILS":
                    return ILS;

                case "GBP":
                    return GBP;

                case "KRW":
                    return KRW;

                case "MYR":
                    return MYR;

                default:
                    return 1;
            }
        }
    }

    public class Currencies
    {
        public Rates rates { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; } 
        public string date { get; set; } 

        public double getCurrency(string Currency)
        {
            return rates.getCurrency(Currency);
        }
    }
}