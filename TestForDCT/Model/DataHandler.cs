using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForDCT.ViewModel;

namespace TestForDCT.Model
{
    public static class DataHandler
    {
        public static List<CryptoCurrency> GetAssets()
        {
            RequestSender request = new();
            request.GetRequest("https://api.coincap.io/v2/assets");
            request.Run();
            string response = request.Response;
            JObject json = JObject.Parse(response);
            var values = json["data"];
            List<CryptoCurrency> result = new();
            foreach (var item in values)
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
                result.Add(currency);
            }
            return result;
        }
        public static List<CryptoCurrency> GetTop10Currencies()
        {
            RequestSender request = new();
            request.GetRequest("https://api.coincap.io/v2/assets");
            request.Run();
            string response = request.Response;
            JObject json = JObject.Parse(response);
            JToken values = json["data"];
            List<CryptoCurrency> result = new();
            foreach (JToken item in values)
            {
                CryptoCurrency currency = new CryptoCurrency
                {
                    Id = (string)item["id"],
                    Name = (string)item["name"],
                    Rank = (int)item["rank"],
                    Symbol = (string)item["symbol"],
                    Explorer = (string)item["explorer"],
                };
                if ((string)item["changePercent24Hr"] != null) currency.ChangePercent24Hr = (decimal)item["changePercent24Hr"];
                if ((string)item["marketCapUsd"] != null) currency.MarketCapUsd = (decimal)item["marketCapUsd"];
                if ((string)item["maxSupply"] != null) currency.MaxSupply = (decimal)item["maxSupply"];
                if ((string)item["priceUsd"] != null) currency.PriceUsd = (decimal)item["priceUsd"];
                if ((string)item["supply"] != null) currency.Supply = (decimal)item["supply"];
                if ((string)item["volumeUsd24Hr"] != null) currency.VolumeUsd24Hr = (decimal)item["volumeUsd24Hr"];
                if ((string)item["vwap24Hr"] != null) currency.Vwap24Hr = (decimal)item["vwap24Hr"];
                result.Add(currency);
                if (result.Count == 10) break;
            }
            return result;
        }
    }
}
