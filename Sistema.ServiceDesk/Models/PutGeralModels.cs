using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.ServiceDesk.Models
{
    public class PutGeralModels
    {
        public int id { get; set; }
        public string analista { get; set; }
        public string nomeDoUsuario { get; set; }
        public string filial { get; set; }
        public int ticket { get; set; }
        public string descricao { get; set; }
    }
}
