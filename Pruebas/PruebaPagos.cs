using Escenarios;
using System;
using ProyectoFinal;
using Xunit;
using Procesos;
using Modelo.ControlPrestamo;

namespace Pruebas
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            Escenario01 Escenario = new Escenario01();
            EscenarioControl control = new EscenarioControl();
//            control.Grabar(Escenario);

            //Proceso Crear un nuevo credito con sus respecivos pagos
            datosCredito Datos = new datosCredito();
            Datos.Generar();
        }

        [Theory]
        //[InlineData("Pagado", "Pagado",  true)]
        //[InlineData("Pendiente","Pagado",  false)]
        [InlineData(3, true)]
        [InlineData(4, true)]
        [InlineData(5, true)]
        [InlineData(6, true)]
        [InlineData(7,  true)]
        [InlineData(8,  true)]
        [InlineData(9,  true)]
        [InlineData(10, true)]
        [InlineData(11, true)]
        [InlineData(12, true)]
        [InlineData(13,false)]
        [InlineData(14,  false)]
        [InlineData(15,  false)]
        [InlineData(16, false)]
        [InlineData(17,  false)]
        [InlineData(18, false)]
        [InlineData(19, false)]
        //static public void Pagos(int id, string stado, bool resEsperado)
        public void Pagos(int id, bool resEsperado)
        {
            // Preparación
            bool resReal;
            //resReal = CreditoPro.ConsultarYvalidarPagos(id, stado);
            resReal = PagosProc.ConsultarYvalidarPagos(id);
            // Validación
            if (resEsperado)
            {
                Assert.True(resReal);
            }
            else
            {
                Assert.False(resReal);
            }
        }
    }
}
