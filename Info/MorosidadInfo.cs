using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class MorosidadInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var morosidad = (Morosidad)entity;
            return String.Format(
                "MorosidadId: {0} \n Dias atraso: {1} \n Interes: {2}",
                morosidad.MorosidadId,
                morosidad.DiasAtraso,
                morosidad.Interes
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var morosidads = (List<Morosidad>)entity;
            string msj = "CalificacionId \t Matricula_DetId \t Notas \n";
            foreach (var morosidad in morosidads)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \n",
                    morosidad.MorosidadId,
                morosidad.DiasAtraso,
                morosidad.Interes
                    );
            }
            return msj;
        }

    }
}
