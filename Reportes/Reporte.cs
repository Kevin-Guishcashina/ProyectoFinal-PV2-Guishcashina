using Microsoft.EntityFrameworkCore;
using Modelo.ControlPrestamo;
using Persistencia;
using System;
using System.Linq;

namespace Reportes
{

    public class Reporte
    {
        //Reporte de pagos de un cliente
        static public Cliente PagosPorCliente(string ClienteNombre)
        {
            Cliente cliente;
            using (var context = new PrestamoContex())
            {
                cliente = context.clientes
                    .Include(cli => cli.Credito)
                    .ThenInclude(cre => cre.Pagos)
                    .ThenInclude(pa => pa.TipoPago)
                    .Single(cli => cli.Nombres.Equals(ClienteNombre));
            }
            return cliente;
        }

        //Reporte de creditos
        public void ReporteCreditos()
        {
            using (var context = new PrestamoContex())
            {
                Console.WriteLine("---------REPORTE DE LOS CREDITOS------------");
                var credito = context.creditos
                    .Include(cre => cre.Cliente)
                    .Include(cre => cre.TipoCredito)
                    .Include(cli => cli.Pagos)
                    .ToList();

                foreach (var cre in credito)
                {
                    Console.WriteLine("Cliente: {0} \t  Credito: {1} \t  Estado: {2} de pagos ",
                        cre.Cliente.Nombres,
                        cre.TipoCredito.nombre,
                        cre.Estado);
                }
            }
        }
        //reporte de pagos de un cliente
        public void ProcesoConsultaCliente()
        {
            using (var context = new PrestamoContex())
            {
                Console.WriteLine("-------Situacaion antes del cambio------");
                var nombreCliente = "Maria Teresa";
                var cliNombre = context.clientes.Where(cli => cli.Nombres == nombreCliente).Single();
                var crediCliente = context.creditos.Where(cre => cre.ValorCredito == 500).Single();

                Console.WriteLine("Este es el credito del cliente {0} {1}", cliNombre.Nombres, cliNombre.Apellidos);
                Console.WriteLine();
                Console.WriteLine("CreditoId \t FechaCredito    \t FrecuenciaPago \t ValorCredito \t CatidadPagos \t Estado");
                Console.WriteLine("{0}       \t {1}  \t {2}        \t {3}      \t {4}     \t {5}", 
                    crediCliente.CreditoId.ToString(), 
                    crediCliente.FechaCredito, 
                    crediCliente.FrecuenciaPago, 
                    crediCliente.ValorCredito, 
                    crediCliente.CantidadDePagos, 
                    crediCliente.Estado);
                Console.WriteLine();

                var pagosClie = context.pagos.Where(pa => pa.CreditoId == 3)
                    .Include(cre => cre.TipoPago)
                    .ToList();
                    
                Console.WriteLine("PagosId \tTipoPago   \t   FechaPago     \t     ValorPago    \t     Credito  \t Estado");
                foreach (var i in pagosClie)
                {
                    var valor = i.ValorPago;
                    Console.WriteLine(" {0}      \t  {1}      \t    {2}      \t    {3}       \t      {4}      \t      {5} ", 
                        i.PagoId.ToString(), 
                        i.TipoPago.Nombre, 
                        i.FechaPago, 
                        MathF.Round(valor, 2), 
                        i.CreditoId, i.Estado);
                }


            }

        }
    }
}
