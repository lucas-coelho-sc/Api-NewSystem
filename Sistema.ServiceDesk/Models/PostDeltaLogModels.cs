using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.ServiceDesk.Models
{
    public class PostDeltaLogModels
    {
        public string motorista { get; set; }
        public string shift { get; set; }
        public string placa { get; set; }
        public ulong imei { get; set; }
        public string analista { get; set; }
        public string problema { get; set; }
        public string acao { get; set; }
    }
}
