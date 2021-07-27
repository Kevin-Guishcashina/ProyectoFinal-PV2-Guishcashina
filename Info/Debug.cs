using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class Debug
    {
        public static void Print(IDBEntity entidad)
        {
            string msj = "";
            if (entidad is Credito)
            {
                msj = CreditoInfo.Publicar((Credito)entidad);
            }
            else if (entidad is Cliente)
            {
                msj = ClienteInfo.Publicar((Cliente)entidad);
            }
            else if (entidad is TipoPago)
            {
                msj = TipoPagoInfo.Publicar((TipoPago)entidad);
            }
            else if (entidad is Pago)
            {
                msj = PagoInfo.Publicar((Pago)entidad);
            }
            else if (entidad is Morosidad)
            {
                msj = MorosidadInfo.Publicar((Morosidad)entidad);
            }
            //
            Console.WriteLine(msj);
        }
        public static void Print(IEnumerable<IDBEntity> lista)
        {
            string msj = "";
            if (lista is List<Credito>)
            {
                msj = CreditoInfo.Publicar(lista);
            }
            else if (lista is List<Cliente>)
            {
                msj = ClienteInfo.Publicar(lista);
            }
            else if (lista is List<TipoPago>)
            {
                msj = TipoPagoInfo.Publicar(lista);
            }
            else if (lista is List<Pago>)
            {
                msj = PagoInfo.Publicar(lista);
            }
            else if (lista is List<Morosidad>)
            {
                msj = MorosidadInfo.Publicar(lista);
            }
            //
            Console.WriteLine(msj);
        }
    }
}
