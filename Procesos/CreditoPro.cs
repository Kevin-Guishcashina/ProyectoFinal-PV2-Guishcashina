using Modelo.ControlPrestamo;
using Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Procesos
{
    public class CreditoPro
    {
        public PrestamoContex _context;


        //Consulta el credito pendiente de un cliente

        public static Credito CrearCredito(PrestamoContex db, string cliNombre, string tipoPagoNombre, DateTime fecha, string taAmortizacion, string frecuenciaPago, string estado, string tipocreditoNombre)
        {
            //1. consulta del cliente
            Cliente cliente = db.clientes.
                Single(cli => cli.Nombres == cliNombre);
            //2. consulta del tipo de pago
            TipoPago tipoPagos = db.tipoPagos
                .Single(tipa => tipa.Nombre == tipoPagoNombre);
            //3. consulta de la tabla amortizacion
            TablaAmortizacion tablaAmort = db.tablaAmortizacions
                .Single(taAm => taAm.nombre == taAmortizacion);
            //4. consultar tipo de credito
            TipoCredito tipocredito = db.tipoCreditos
                .Single(tip => tip.nombre == tipocreditoNombre);
            //Cabecera del credito

            //regla de negocio 
            //si el pago aun no se 
           

            Credito creditoMaria = new Credito()
            {
                FechaCredito = fecha,
                Cliente = cliente,
                TipoCredito = tipocredito,
                TablaAmortizacion = tablaAmort,
                FrecuenciaPago = frecuenciaPago,
                ValorCredito = 500,
                PlazoAnios = 1,
                CantidadDePagos = 12,
                Estado = estado
            };
            
            return creditoMaria;
        }

        
        

    }
}
