using Escenarios;
using Reportes;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Info;
using Modelo.ControlPrestamo;
using Procesos;

namespace ProyectoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            var Escenario = new Escenario01();
            var EscenarioControl = new EscenarioControl();
            EscenarioControl.Grabar(Escenario);

            //Proceso Crear un nuevo credito con sus respecivos pagos
            datosCredito D = new datosCredito();
            D.Generar();

            //Proceso de consulta de los apgos de un credito 
            Reporte re = new Reporte();
            re.ProcesoConsultaCliente();
            //Reporte de los creditos con sus estados

            re.ReporteCreditos();

        }


    }
}
