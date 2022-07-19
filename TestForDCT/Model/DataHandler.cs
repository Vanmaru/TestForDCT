using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForDCT.ViewModel;

namespace TestForDCT.Model
{
    class DataHandler
    {
        public void GetAssets()
        {
            GetRequest request = new("https://api.coincap.io/v2/assets");
            request.Run();
            string response = request.Response;
            JObject json = JObject.Parse(response);
        }
    }
}
