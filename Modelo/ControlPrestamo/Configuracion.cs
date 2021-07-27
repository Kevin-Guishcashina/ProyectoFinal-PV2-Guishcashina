using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ControlPrestamo
{
    public class Configuracion : IDBEntity
    {   
        public int ConfiguracionId { get; set; }

        public string NombreOrganizacion { get; set; }
        public int MontoMaximoCredito { get; set; }
        public string PlazoMaximoCredito { get; set; }

        public List<TipoCredito> TipoCreditos { get; set; }
    }
}
