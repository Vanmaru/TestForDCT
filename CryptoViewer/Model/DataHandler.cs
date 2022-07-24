using CryptoViewer.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoViewer.Model
{
    public static class DataHandler
    {
        private static JObject GetRequest(string url)
        {
            RequestSender request = new RequestSender();
            request.GetRequest(url);
            request.Run();
            string response = request.Response;
            JObject json = JObject.Parse(response);
            return json;
        }
        private static CryptoCurrency ReadJson(JToken item)
        {
            CryptoCurrency currency = new CryptoCurrency();
            currency.Id = (string)item["id"];
            currency.Name = (string)item["name"];
            currency.Rank = (int)item["rank"];
            currency.Symbol = (string)item["symbol"];
            currency.Explorer = (string)item["explorer"];
            if ((string)item["changePercent24Hr"] != null) currency.ChangePercent24Hr = (decimal)item["changePercent24Hr"];
            if ((string)item["marketCapUsd"] != null) currency.MarketCapUsd = (decimal)item["marketCapUsd"];
            if ((string)item["maxSupply"] != null) currency.MaxSupply = (decimal)item["maxSupply"];
            if ((string)item["priceUsd"] != null) currency.PriceUsd = (decimal)item["priceUsd"];
            if ((string)item["supply"] != null) currency.Supply = (decimal)item["supply"];
            if ((string)item["volumeUsd24Hr"] != null) currency.VolumeUsd24Hr = (decimal)item["volumeUsd24Hr"];
            if ((string)item["vwap24Hr"] != null) currency.Vwap24Hr = (decimal)item["vwap24Hr"];
            return currency;
        }
        public static List<CryptoCurrency> GetAssets()
        {
            JObject json = GetRequest("https://api.coincap.io/v2/assets");
            JToken values = json["data"];
            List<CryptoCurrency> result = new List<CryptoCurrency>();
            foreach (var item in values)
            {
                result.Add(ReadJson(item));
            }
            return result;
        }
        public static List<CryptoCurrency> GetTop10Currencies()
        {
            JObject json = GetRequest("https://api.coincap.io/v2/assets");
            JToken values = json["data"];
            List<CryptoCurrency> result = new List<CryptoCurrency>();
            foreach (JToken item in values)
            {
                result.Add(ReadJson(item));
                if (result.Count == 10) break;
            }
            return result;
        }
        public static CryptoCurrency GetByName(string name)
        {
            string n = name.ToLower();
            JObject json = GetRequest($"https://api.coincap.io/v2/assets/{name.ToLower()}");
            JToken value = json["data"];
            return ReadJson(value);
        }
        //TODO: RequestSender, GetByName
    }
}
