using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ControlPrestamo
{
    public class TipoPago : IDBEntity
    {
        public int TipoPagoId { get; set; }
        public string Nombre { get; set; }
        public List<Pago> Pagos { get; set; }
    }
}
