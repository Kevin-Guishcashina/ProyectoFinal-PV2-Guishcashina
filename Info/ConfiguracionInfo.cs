using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class ConfiguracionInfo : EntityInfo
    {
        public new static string Publicar(IDBEntity entidad)
        {
            var configuracion = (Configuracion)entidad;
            return String.Format(
                "Institución:  {0} \n MontoMaximo: {1} \n PlazoMaximo: {2}",
                configuracion.NombreOrganizacion,
                configuracion.MontoMaximoCredito,
                configuracion.PlazoMaximoCredito
                );
        }

        public static new string Publicar(IEnumerable<IDBEntity> lista)
        {
            string msj = "EscuelaNombre \t PeriodoVigenteId \t NotaMinima \t Pesos \n";
            var configuraciones = (List<Configuracion>)lista;
            foreach (var configuracion in configuraciones)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \n",
                    configuracion.NombreOrganizacion,
                configuracion.MontoMaximoCredito,
                configuracion.PlazoMaximoCredito
                );
            }
            return msj;
        }


    }

}