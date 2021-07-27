using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escenarios
{
    public class Escenario
    {
        public enum ListaTipo
        {
            Clientes, Configuracion, Creditos, TipoPagos, Pagos, 
            TablaAmortizacions, TipoCreditos , Morosidads
        };
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> datos;

        public Escenario()
        {
            datos = new();
        }
    }
}
