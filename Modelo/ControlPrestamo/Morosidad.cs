using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ControlPrestamo
{
    public class Morosidad : IDBEntity
    {
        public int MorosidadId { get; set; }
        public String DiasAtraso { get; set; }

        public int Interes { get; set; }

        public List<Pago> Pagos { get; set; }
    }
}
