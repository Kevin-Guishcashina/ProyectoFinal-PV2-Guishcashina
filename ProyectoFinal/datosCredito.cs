using Modelo.ControlPrestamo;
using Persistencia;
using Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class datosCredito
    {
        //Estados de las matriculas
        public enum CreditoEstado { Completo, EnProceso};

        public void Generar()
        {
            //Cliente y credito
            string cliNombre = "Maria Teresa";
            string tipoPago = "Efectivo";
            Credito creMaria;
            string taAmortizacion = "Francesa";
            string FrecuenciaPago = "Mensual";
            string tipocredito = "Productivo corporativo";
            DateTime fecha = new DateTime(2021, 12, 27);

            //DATOS PARA EL REGISTRO DE LOS PAGOS
            //PRIMER PAGO
            Pago pagosMaria1;
            DateTime fechaPago = new DateTime(2022, 1, 26);
            string tipPago = "Efectivo";
            float valorPago = 43.73f;
            string morosidad = "Normal";
            string estado = "Pagado";
            //SEGUNDO PAGO
            Pago pagosMaria2;
            DateTime fechaPago2 = new DateTime(2022, 2, 25);
            string tipPago2 = "Efectivo";
            float valorPago2 = 43.73f;
            string morosidad2 = "Normal";
            string estado2 = "Pagado";
            //TERCER PAGO
            Pago pagosMaria3;
            DateTime fechaPago3 = new DateTime(2022, 3, 27);
            string tipPago3 = "Efectivo";
            float valorPago3 = 43.73f;
            string morosidad3 = "Normal";
            string estado3 = "Pagado";
            //CUARTO PAGO
            Pago pagosMaria4;
            DateTime fechaPago4 = new DateTime(2022, 4, 26);
            string tipPago4 = "Efectivo";
            float valorPago4 = 43.73f;
            string morosidad4 = "Normal";
            string estado4 = "Pagado";
            //QUINTO PAGO
            Pago pagosMaria5;
            DateTime fechaPago5 = new DateTime(2022, 5, 26); string tipPago5 = "Efectivo"; float valorPago5 = 43.73f; string morosidad5 = "Normal"; string estado5 ="Pagado";
            //SEXTO PAGO
            Pago pagosMaria6;
            DateTime fechaPago6 = new DateTime(2022, 6, 25); string tipPago6 = "NoRealizado"; float valorPago6 = 43.73f; string morosidad6 = "Normal"; string estado6 = "Pendiente";
            //SEXTIMO PAGO
            Pago pagosMaria7;
            DateTime fechaPago7 = new DateTime(2022, 7, 25); string tipPago7 = "NoRealizado"; float valorPago7 = 43.73f; string morosidad7 = "Normal"; string estado7 = "Pendiente";
            //OCTAVO PAGO
            Pago pagosMaria8;
            DateTime fechaPago8 = new DateTime(2022, 8, 24); string tipPago8 = "NoRealizado"; float valorPago8 = 43.73f; string morosidad8 = "Normal"; string estado8 = "Pendiente";
            //NOVENO PAGO
            Pago pagosMaria9;
            DateTime fechaPago9 = new DateTime(2022, 9, 23); string tipPago9 = "NoRealizado"; float valorPago9 = 43.73f; string morosidad9 = "Normal"; string estado9 = "Pendiente";
            //DECIMO PAGO
            Pago pagosMaria10;
            DateTime fechaPago10 = new DateTime(2022, 10, 23); string tipPago10 = "NoRealizado"; float valorPago10 = 43.73f; string morosidad10 = "Normal"; string estado10 = "Pendiente";
            //DECIMOPRIMERO PAGO
            Pago pagosMaria11;
            DateTime fechaPago11 = new DateTime(2022, 11, 22); string tipPago11 = "NoRealizado"; float valorPago11 = 43.73f; string morosidad11 = "Normal"; string estado11 = "Pendiente";
            //DECIMOSEGUNDO PAGO
            Pago pagosMaria12;
            DateTime fechaPago12 = new DateTime(2022, 12, 22); string tipPago12 = "NoRealizado"; float valorPago12 = 43.73f; string morosidad12 = "Normal"; string estado12 = "Pendiente";


            //Envio de datos al los metodos para la creacion del nuevo credito 
            using (var db = new PrestamoContex())
            {
                creMaria = CreditoPro.CrearCredito(db, cliNombre, tipoPago, fecha, taAmortizacion, FrecuenciaPago,
                    CreditoEstado.EnProceso.ToString(), tipocredito);
             
                pagosMaria1 = PagosProc.RegistroPagos(db, tipPago, fechaPago, valorPago, creMaria, morosidad,estado);
                pagosMaria2 = PagosProc.RegistroPagos(db, tipPago2, fechaPago2, valorPago2, creMaria, morosidad2,estado2);
                pagosMaria3 = PagosProc.RegistroPagos(db, tipPago3, fechaPago3, valorPago3, creMaria, morosidad3,estado3);
                pagosMaria4 = PagosProc.RegistroPagos(db, tipPago4, fechaPago4, valorPago4, creMaria, morosidad4,estado4);
                pagosMaria5 = PagosProc.RegistroPagos(db, tipPago5, fechaPago5, valorPago5, creMaria, morosidad5,estado5);
                pagosMaria6 = PagosProc.RegistroPagos(db, tipPago6, fechaPago6, valorPago6, creMaria, morosidad6, estado6);
                pagosMaria7 = PagosProc.RegistroPagos(db, tipPago7, fechaPago7, valorPago7, creMaria, morosidad7, estado7);
                pagosMaria8 = PagosProc.RegistroPagos(db, tipPago8, fechaPago8, valorPago8, creMaria, morosidad8, estado8);
                pagosMaria9 = PagosProc.RegistroPagos(db, tipPago9, fechaPago9, valorPago9, creMaria, morosidad9, estado9);
                pagosMaria10 = PagosProc.RegistroPagos(db, tipPago10, fechaPago10, valorPago10, creMaria, morosidad10, estado10);
                pagosMaria11 = PagosProc.RegistroPagos(db, tipPago11, fechaPago11, valorPago11, creMaria, morosidad11, estado11);
                pagosMaria12 = PagosProc.RegistroPagos(db, tipPago12, fechaPago12, valorPago12, creMaria, morosidad12, estado12);
                
                db.creditos.Add(creMaria);
                db.pagos.Add(pagosMaria1);
                db.pagos.Add(pagosMaria2);
                db.pagos.Add(pagosMaria3);
                db.pagos.Add(pagosMaria4);
                db.pagos.Add(pagosMaria5);
                db.pagos.Add(pagosMaria6);
                db.pagos.Add(pagosMaria7);
                db.pagos.Add(pagosMaria8);
                db.pagos.Add(pagosMaria9);
                db.pagos.Add(pagosMaria10);
                db.pagos.Add(pagosMaria11);
                db.pagos.Add(pagosMaria12);
              
            }

            

           
            


        }

        
    }
}
