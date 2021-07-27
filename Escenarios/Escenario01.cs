using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escenarios
{
    public class Escenario01 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> carga()
        {
            //CONFIGURACION
            Configuracion config = new()
            {
                NombreOrganizacion = "Banco de Ahorros y Credito",
                MontoMaximoCredito = 10000,
                PlazoMaximoCredito = "5 años",
            };
            List<Configuracion> lstConfiguracion = new()
            {
                config
            };
            datos.Add(ListaTipo.Configuracion, lstConfiguracion);
            //INGRESO DE CLIENTES
            Cliente CManuel = new()
            {
                Nombres = "Luis Manuel",
                Apellidos = "Garcia Toapanta",
                edad = 25,
                Genero = "Maculino",
                Telefono = 3152485,
                Direccion = "El tejar",
            };
            Cliente CMaria = new() { Nombres = "Maria Teresa", Apellidos = "Malan Malan", edad = 32, Genero = "Femenino", Telefono = 3789546, Direccion = "El norte", };
            Cliente CJorge = new() { Nombres = "Mario Jorge", Apellidos = "Sanchez Lopez", edad = 20, Genero = "Masculino", Telefono = 4521476, Direccion = "El sur", };
            List<Cliente> ltsClientes = new()
            {
                CManuel,
                CJorge, CMaria
            };
            datos.Add(ListaTipo.Clientes, ltsClientes);

            //TIPOP DE TIPO CREDITO
            TipoCredito TCEducativo = new()
            {
                nombre = "Educativo",
                interes = 9.5,

            };
            TipoCredito TCProducCorp = new() { nombre = "Productivo corporativo", interes = 9.33 };
            TipoCredito TCProducEmpre = new() { nombre = "Productivo empresarial", interes = 90.21 };
            TipoCredito TCProducPymes = new() { nombre = "Productivo PYMES", interes = 11.83 };
            TipoCredito TCComercialOrd = new() { nombre = "Comercial ordinario", interes = 11.83 };
            TipoCredito TCComercialPrioCorp = new() { nombre = "Comercial prioritario Corporativo", interes = 9.33 };
            TipoCredito TCComercialPrioEmp = new() { nombre = "Comercial prioritario empresarial", interes = 9.33 };
            TipoCredito TCComercialPrioPymes = new() { nombre = "Comercial prioritario PYMES", interes = 11.83 };
            TipoCredito TCConOrd = new() { nombre = "Consumo ordinario", interes = 17.3 };
            TipoCredito TCConPrio = new() { nombre = "Consumo prioritario", interes = 17.3 };
            List<TipoCredito> lstTipoCredito = new()
            {
                TCProducCorp, TCProducEmpre, TCProducPymes,TCComercialOrd,
                TCComercialPrioCorp,
                TCComercialPrioEmp,
                TCComercialPrioPymes,
                TCConOrd,
                TCConPrio
            };
            datos.Add(ListaTipo.TipoCreditos, lstTipoCredito);

            //TIPO DE TABLA
            TablaAmortizacion TAFrancesa = new TablaAmortizacion()
            {
                nombre = "Francesa",
            };
            TablaAmortizacion TAAlenama = new TablaAmortizacion()
            {
                nombre = "Alemana",
            };
            List<TablaAmortizacion> lstTablaAmortizacion = new()
            {
                TAAlenama, TAFrancesa
            };
            datos.Add(ListaTipo.TablaAmortizacions, lstTablaAmortizacion);
          

            //CEDITO
            Credito PrimerCredito = new Credito()
            {
                FechaCredito = new DateTime(2021,6,18),
                Cliente = CManuel,
                TipoCredito = TCEducativo,
                TablaAmortizacion = TAFrancesa,
                FrecuenciaPago = "Mensual",
                ValorCredito = 1000,
                PlazoAnios = 1,
                CantidadDePagos = 12,
                Estado = "Pendiente"
            };
            Credito SegundoCredito = new Credito()
            {
                FechaCredito = new DateTime(2021, 7, 23),
                Cliente = CMaria,
                TipoCredito = TCComercialOrd,
                TablaAmortizacion = TAFrancesa,
                FrecuenciaPago = "Trimestral",
                ValorCredito = 2000,
                PlazoAnios = 1,
                CantidadDePagos = 4,
                Estado = "Completo"
            };
            List<Credito> lstcredito = new()
            {
                PrimerCredito, SegundoCredito
            };
            datos.Add(ListaTipo.Creditos, lstcredito);
            //Morosidad
            Morosidad Normal = new()
            {
                DiasAtraso = "Normal",
                Interes = 0,
            };
            Morosidad UnoAQuince = new() { DiasAtraso = "1 a 15 dias", Interes = 5 };
            Morosidad DiesiseisATreinta = new() { DiasAtraso = "16 a 30 dias", Interes = 7 };
            Morosidad TreintaUnoASesenta = new() { DiasAtraso = "31 a 60 dias", Interes = 9 };
            Morosidad MasSesenta = new() { DiasAtraso = "Mas de 60 dias", Interes = 10 };
            List<Morosidad> lstMorosidad = new()
            {
                Normal,UnoAQuince, DiesiseisATreinta, TreintaUnoASesenta, MasSesenta
            };
            datos.Add(ListaTipo.Morosidads, lstMorosidad);

            //TIPO PAGO

            TipoPago PagoTarjeta = new()
            {
                Nombre = "Tarjeta de credito"
            };
            TipoPago PagoPaypal = new()
            {
                Nombre = "Paypal"
            };
            TipoPago PagoTransferencia = new()
            {
                Nombre = "Transferencia"
            };
            TipoPago PagoEfectivo = new()
            {
                Nombre = "Efectivo",

            };
            TipoPago NoRealizado = new()
            {
                Nombre = "NoRealizado",
            };
            List<TipoPago> lstTipoPago = new List<TipoPago>()
            {
                PagoEfectivo, PagoTarjeta, PagoPaypal, PagoTransferencia, NoRealizado
            };
            datos.Add(ListaTipo.TipoPagos, lstTipoPago);

            //PAGOS

            Pago primerPago = new Pago()
            {
                TipoPago = PagoEfectivo,
                FechaPago = new DateTime(2021, 7, 18),
                ValorPago = 437.26f,
                Credito = PrimerCredito,
                Morosidad = Normal,
                Estado = "Pagado"
              
            };
            Pago segundoPago = new Pago() { TipoPago = PagoEfectivo, FechaPago = new DateTime(2021, 8, 18), ValorPago = 437.26f, Credito = PrimerCredito, Morosidad = Normal, Estado = "Pagado" };
            Pago tercerPago = new Pago() { TipoPago = PagoEfectivo, FechaPago = new DateTime(2021, 9, 18), ValorPago = 437.26f, Credito = PrimerCredito, Morosidad = Normal, Estado = "Pagado" };
            //pagos del segundo credito
            Pago PrimerPago_SegundoCredito = new Pago() { TipoPago = PagoEfectivo, FechaPago = new DateTime(2021, 8, 23), ValorPago =  528.44f, Credito = SegundoCredito, Morosidad = Normal, Estado = "Pagado" };
            Pago SegundoPago_SegundoCredito = new Pago() { TipoPago = PagoEfectivo, FechaPago = new DateTime(2021, 9, 23), ValorPago = 528.44f, Credito = SegundoCredito, Morosidad = Normal, Estado = "Pagado" };
            Pago TercerPago_SegundoCredito = new Pago() { TipoPago = PagoEfectivo, FechaPago = new DateTime(2021, 10, 23), ValorPago = 528.44f, Credito = SegundoCredito, Morosidad = Normal, Estado = "Pagado" };
            Pago CuartoPago_SegundoCredito = new Pago() { TipoPago = PagoEfectivo, FechaPago = new DateTime(2021, 11, 23), ValorPago = 528.44f, Credito = SegundoCredito, Morosidad = Normal, Estado = "Pagado" };

            List<Pago> lstPago = new()
            {
                primerPago, segundoPago, tercerPago,
                PrimerPago_SegundoCredito,
                SegundoPago_SegundoCredito,
                TercerPago_SegundoCredito,
                CuartoPago_SegundoCredito
            };
            datos.Add(ListaTipo.Pagos, lstPago);

            //retorna datos
            return datos;

        }
    }
}
