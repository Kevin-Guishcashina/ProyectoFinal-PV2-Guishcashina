using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class TipoCreditoInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var tipoCredito = (TipoCredito)entity;
            return String.Format(
                "TipoCreditoId: {0} \n Nombre: {1} \n Interes: {2}",
                tipoCredito.tipoCreditoId,
                tipoCredito.nombre,
                tipoCredito.interes
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var tipoCreditos = (List<TipoCredito>)entity;
            string msj = "CalificacionId \t Matricula_DetId \t Notas \n";
            foreach (var tipoCredito in tipoCreditos)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \n",
                    tipoCredito.tipoCreditoId,
                tipoCredito.nombre,
                tipoCredito.interes
                    );
            }
            return msj;
        }

    }
}
