using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ControlPrestamo
{
    public class Pago : IDBEntity
    {
        public int PagoId { get; set; }
        public TipoPago TipoPago {get; set; } 
        public int TipoPagoId { get; set; }
        public DateTime FechaPago { get; set; }
        public float ValorPago { get; set; }
        public Credito Credito { get; set; }
        public int CreditoId { get; set; }

        public Morosidad Morosidad { get; set; } 


        public string Estado { get; set; }

       static public bool cumple(string estado)
        {
            bool res;
            res = estado == "Pagado";
            Console.WriteLine(res);
            return res;
        }
    
    }
}
