using Escenarios;
using Modelo.ControlPrestamo;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Escenarios.Escenario;

namespace ProyectoFinal
{
    public class EscenarioControl
    {
        public void Grabar(IEscenario escenario)
        {
            var datos = escenario.carga();
            using (var db = new PrestamoContex())
            {
                //Reiniciamos la Base de datos
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                //Insertamos los datos
                db.configuracions.AddRange      ((List<Configuracion>)    datos[ListaTipo.Configuracion]);
                db.clientes.AddRange            ((List<Cliente>)          datos[ListaTipo.Clientes]);
                db.tipoCreditos.AddRange        ((List<TipoCredito>)      datos[ListaTipo.TipoCreditos]);
                db.tipoPagos.AddRange           ((List<TipoPago>)         datos[ListaTipo.TipoPagos]);
                db.tablaAmortizacions.AddRange  ((List<TablaAmortizacion>)datos[ListaTipo.TablaAmortizacions]);
                db.creditos.AddRange            ((List<Credito>)          datos[ListaTipo.Creditos]);
                db.pagos.AddRange               ((List<Pago>)             datos[ListaTipo.Pagos]);
                //Genera la persistencia
                db.SaveChanges();
            }
        }
    }
}
