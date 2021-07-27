using Microsoft.EntityFrameworkCore;
using Modelo.ControlPrestamo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class PagosProc
    {
        static public bool ConsultarYvalidarPagos(int id)
        {

            using (var db = new PrestamoContex())
            {
                Pago pago = db.pagos
                    .Single(cl => cl.PagoId == id);
                //Console.WriteLine("id" + pago.PagoId);
                //Console.WriteLine("estado estado" + pago.Estado);
                var a = Pago.cumple(pago.Estado);
                return a;
            }
        }

        public static Pago RegistroPagos(PrestamoContex db, 
            string tipPago, DateTime fechaPago, 
            float valorPago, Credito creMaria, 
            string morosidad, string estado)
        {
            //Consutla el tipo de pago
            TipoPago tipopago = db.tipoPagos
                .Single(tp => tp.Nombre == tipPago);
            //Consultar Morosidad
            Morosidad mo = db.morosidads
                .Single(mo => mo.DiasAtraso == morosidad);
            //consulta tipo de pagos 
            TipoPago tp = db.tipoPagos
                .Single(tp => tp.Nombre == tipPago);

            //Regla de negocio 
            //Si la cuota a pagar no se realizo el estado estara en pendiente 
            // si la couta a pagar se a realizado el estado cambiara a Pagado
            string NombrePago;
            if (tipPago == "NoRealizado")
            {
                NombrePago = "Pendiente";
            }
            else
            {
                NombrePago = "Pagado";
            }

            ///Se procede a la ceacion de los pagos y registro
            Pago pago = new Pago()
            {
                TipoPago = tp,
                FechaPago = fechaPago,
                ValorPago = valorPago,
                Credito = creMaria,
                Morosidad = mo,
                Estado = NombrePago
            };

            try
            {
                db.pagos.Add(pago);
                db.SaveChanges();

            }
            catch (DbUpdateConcurrencyException exception)
            {
                Exception ex = new Exception("Conflicto de concurrencia", exception);
            }
            return pago;
        }

    }
}
