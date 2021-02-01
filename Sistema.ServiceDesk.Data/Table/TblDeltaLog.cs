using System;

namespace Sistema.ServiceDesk.Data
{
    public class TblDeltaLog
    {
        public int id { get; set; }
        public string motorista { get; set; }
        public string shift { get; set; }
        public string placa { get; set; }
        public ulong imei { get; set; }
        public string analista { get; set; }
        public string problema { get; set; }
        public string acao { get; set; }
        public string data { get; set; }

        public TblDeltaLog()
        {
            data = Convert.ToString(DateTime.Now);
        }
        
         
        
    }
   
}
