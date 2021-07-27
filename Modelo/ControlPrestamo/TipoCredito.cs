using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ControlPrestamo
{
    public class TipoCredito : IDBEntity
    {
        public int tipoCreditoId { get; set; }

        public string nombre {get; set;}
        
        public double interes { get; set; }

        public List<Credito> Creditos { get; set; }
    }
}
