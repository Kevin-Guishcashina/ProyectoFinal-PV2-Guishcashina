using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class PagoInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var pago = (Pago)entity;
            return String.Format(
                "PagoId: {0} \n TipoPagoId: {1} \n FechaPago: {2} \n ValorPago: {3} \n CreditoId: {4} \n MorosidadId: {5}",
                pago.PagoId,
                pago.TipoPagoId,
                pago.FechaPago,
                pago.ValorPago,
                pago.CreditoId,
                pago.Morosidad
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var pagos = (List<Pago>)entity;
            string msj = "PagoId \t TipoPagoId \t FechaPago \t ValorPago \t CreditoId \t MorosidadId \n";
            foreach (var pago in pagos)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \t {3} \t {4} \t {5}\n",
                    pago.PagoId,
                pago.TipoPagoId,
                pago.FechaPago,
                pago.ValorPago,
                pago.CreditoId,
                pago.Morosidad
                    );
            }
            return msj;
        }

    }
}
