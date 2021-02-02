using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.ServiceDesk.Data
{
    public class TblGeral
    {
        public int id { get; set; }
        public string? analista { get; set; }
        public string nomeDoUsuario { get; set; }
        public string filial { get; set; }
        public int ticket { get; set; }
        public string descricao { get; set; }
        public string data { get; set; }

        public TblGeral()
        {
            data = Convert.ToString(DateTime.Now);
        }
    }
}
