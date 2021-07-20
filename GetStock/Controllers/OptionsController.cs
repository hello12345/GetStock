using GetStock.Repository;
using GetStock.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetStock.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private IOptions _IOptions;
        public OptionsController(IOptions IOptions)
        {
            this._IOptions = IOptions;
        }
        [HttpGet]
        public async Task<RespOiData> getOidata(string underlying, string date, string dur, bool hist)
        {

            var resp=await _IOptions.getOidata(underlying,date,dur,hist);
            return resp;
        }
        public async Task<RespOiData> getoistrike(string underlying)
        {

            var resp = await _IOptions.getoistrike(underlying);
            return resp;
        }

    }
}
