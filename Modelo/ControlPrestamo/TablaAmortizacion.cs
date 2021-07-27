using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ControlPrestamo
{
    public class TablaAmortizacion : IDBEntity
    {
        public int TablaAmortizacionId { get; set; }
        public string nombre { get; set; }

        public List<Credito> Creditos { get; set; }
    }
}
