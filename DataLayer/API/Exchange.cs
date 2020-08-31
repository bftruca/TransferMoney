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
    public sealed class Exchange
    {
        private static Exchange instance = null;

        private Exchange()
        {

        }

        public static Exchange Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Exchange();
                }
                return instance;
            }
        }

        public Currencies GetCurrencies()
        {
            try
            {
                var client = new RestClient("https://api.exchangeratesapi.io/latest");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                //request.AddHeader("Cookie", "__cfduid=dba785c1da4fd09c2bb0a024b699137491598839016");
                IRestResponse response = client.Execute(request);

                Currencies myDeserializedCurrencies = JsonConvert.DeserializeObject<Currencies>(response.Content);

                return myDeserializedCurrencies;
            }
            catch (Exception ex)
            {
                Logger.log(string.Format("Exchange.GetCurrencies(): {0}", ex.Message));
                throw ex;
            }
        }
    }
}