using GetStock.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetStock.Repository
{
    public interface IOptions
    {
       Task<RespOiData> getOidata(string underlying,string date,string dur,bool hist);
      Task<RespOiData> getoistrike(string underlying);
    }
}
