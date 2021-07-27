using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class TablaAmortizacionInfo: EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var tabla = (TablaAmortizacion)entity;
            return String.Format(
                "TablaAmortizacionId: {0} \n Nombre: {1}",
                tabla.TablaAmortizacionId,
                tabla.nombre
            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var tablas = (List<TablaAmortizacion>)entity;
            string msj = "TablaAmortizacionId \t Nombre \n";
            foreach (var tabla in tablas)
            {
                msj += String.Format(
                    "{0} \t {1} \n",
                    tabla.TablaAmortizacionId,
                    tabla.nombre
                    );
            }
            return msj;
        }

    }
}
