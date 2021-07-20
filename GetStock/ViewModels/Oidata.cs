using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetStock.ViewModels
{
    public class Oidata
    {
        public int x { get; set; }
        public int y { get; set; }
        public string type { get; set; }
    }
    public class oistrike
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    public class RespOiData
    {
        public List<object> Oidata {    get; set; }
        public string datetime { get; set; }


    }
}
