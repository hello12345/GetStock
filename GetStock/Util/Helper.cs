using GetStock.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetStock.Util
{
    public class Helper
    {
        public async Task<RespOiData> HttpPost(string url, object data)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            //var body = @"{""underlying"":""NIFTY"",""dur"":""15"",""hist"":false,""date"":""""}";
            var body = JsonConvert.SerializeObject(data);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            var resData = response.Content;
            var str = resData.Replace(@"\", "");
            string stringBeforeChar = str.Substring(2, str.IndexOf("]") - 1);
            string stringAfterChar = resData.Substring(resData.IndexOf("]") + 3).Replace("]", "");
            var resOidata = new RespOiData();
            resOidata.Oidata = JsonConvert.DeserializeObject<List<object>>(stringBeforeChar);
            resOidata.datetime = stringAfterChar;
            return resOidata;
        }
    }
}
