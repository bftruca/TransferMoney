using MoneyTransfer.DataLayer.API.Models;
using MoneyTransfer.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTransfer.DataLayer.API
{
    public sealed class CheckIBAN
    {
        private static CheckIBAN instance = null;

        private CheckIBAN()
        {
        }

        public static CheckIBAN Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CheckIBAN();
                }

                return instance;
            }
        }

        public bool Check(string IBAN)
        {
            try
            {
                var client = new RestClient(string.Format("https://openiban.com/validate/{0}", IBAN));
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                IBAN myDeserializedIBAN = JsonConvert.DeserializeObject<IBAN>(response.Content);

                return myDeserializedIBAN.valid;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("CheckIBAN.Check(): {0}", ex.Message));
                throw ex;
            }            
        }
    }
}