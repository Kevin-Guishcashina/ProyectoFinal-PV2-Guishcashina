using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class CreditoInfo : EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var credito = (Credito)entity;
            return String.Format(
                "CreditoID: {0} \n Fecha credito: {1} \n ClienteId: {2} \n Tipo creditoId: {3} \n Tabla amortizacionId {4} \n Frecuencia pago {5} \n Valor credito {6} \n Plazo años {7}",
                credito.CreditoId,
                credito.FechaCredito,
                credito.ClienteId,
                credito.TipoCreditoId,
                credito.TablaAmortizacionID,
                credito.FrecuenciaPago,
                credito.ValorCredito,
                credito.PlazoAnios

            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var creditos = (List<Credito>)entity;
            string msj = "CreditoID: \t Fecha credito: \t ClienteId: \t Tipo creditoId: \t Tabla amortizacionId \t Frecuencia pago \t Valor credito \t Plazo años \n";
            foreach (var credito in creditos)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \n",
                    credito.CreditoId,
                    credito.FechaCredito,
                    credito.ClienteId,
                    credito.TipoCreditoId,
                    credito.TablaAmortizacionID,
                    credito.FrecuenciaPago,
                    credito.ValorCredito,
                    credito.PlazoAnios
                    );
            }
            return msj;
        }
    }
}
