using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.ServiceDesk.Models
{
    public class GetDeltaLogModels
    {
        public string shift { get; set; }
        public string placa { get; set; }
        public ulong imei { get; set; }
    }
}
