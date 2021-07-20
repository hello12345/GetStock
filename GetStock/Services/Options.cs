using GetStock.Repository;
using GetStock.Util;
using GetStock.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace GetStock.Services
{
    public class Options : IOptions
    {
        
        public async Task<RespOiData> getOidata(string underlying, string date, string dur, bool hist)
        {
            Helper helper = new Helper();
            var data = Tuple.Create(underlying, dur, hist, date);
            dynamic MyDynamic = new ExpandoObject();
            MyDynamic.underlying = underlying;
            MyDynamic.dur = dur;
            MyDynamic.hist = hist;
            MyDynamic.date = date;

            var userData = MyDynamic;
            //{"underlying":underlying,"dur":dur,"hist":hist,"date":date};
            var resp = await helper.HttpPost("https://tradingtick.com/options/oidata.php", userData);
            //return JsonConvert.DeserializeObject<List<Oidata>>(resp);
            return resp;
        }
        public async Task<RespOiData> getoistrike(string underlying)
        {
            Helper helper = new Helper();
            dynamic MyDynamic = new ExpandoObject();
            MyDynamic.underlying = underlying;
            var userData = MyDynamic;
            //{"underlying":underlying,"dur":dur,"hist":hist,"date":date};
            var resp = await helper.HttpPost("https://tradingtick.com/options/trending-oi-strike.php", userData);
            //return JsonConvert.DeserializeObject<List<Oidata>>(resp);
            return resp;
        }
    }
}
