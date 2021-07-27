using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class TipoPagoInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var tipoPago = (TipoPago)entity;
            return String.Format(
                "TipoPagoId: {0} \n Nombre: {1}",
                tipoPago.TipoPagoId,
                tipoPago.Nombre
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var tipoPagos = (List<TipoPago>)entity;
            string msj = "CalificacionId \t Matricula_DetId \t Notas \n";
            foreach (var tipoPago in tipoPagos)
            {
                msj += String.Format(
                    "{0} \t {1}  \n",
                    tipoPago.TipoPagoId,
                    tipoPago.Nombre
                    );
            }
            return msj;
        }

    }
}
