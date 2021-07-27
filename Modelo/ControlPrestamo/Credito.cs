using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ControlPrestamo
{
    public class Credito : IDBEntity
    {
        public int CreditoId { get; set; }

        public DateTime FechaCredito { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public int TipoCreditoId { get; set; }

        public List<Pago> Pagos { get; set; }

        public TablaAmortizacion TablaAmortizacion { get; set; }

        public int TablaAmortizacionID { get; set; }

        public string FrecuenciaPago { get; set; }

        public float ValorCredito { get; set; }

        public int PlazoAnios { get; set; }

        public int CantidadDePagos { get; set; }
        public string Estado { get; set; }

    }
}
