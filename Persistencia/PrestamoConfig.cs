using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class PrestamoConfig
    {
        static public string PersistenciaDestino;
        static public string connectionString;
        static public bool modoVirtual;
        static public string DBMemory;

        static PrestamoConfig()
        {
           
            PersistenciaDestino = ConfigurationManager.AppSettings["PersistenciaDestino"].ToString();
            connectionString = ConfigurationManager.ConnectionStrings[PersistenciaDestino].ToString();
            Console.WriteLine(PersistenciaDestino + " " + connectionString);
        }

        static public DbContextOptions<PrestamoContex> ContextOptions()
        {

            DbContextOptions<PrestamoContex> opciones = null;
            modoVirtual = true;
            switch (PersistenciaDestino)
            {
                case "SQLServerPrestamo":
                    opciones = new DbContextOptionsBuilder<PrestamoContex>()
                        .UseSqlServer(connectionString)
                        .Options;
                    break;
                case "PostgresPrestamo":
                    opciones = new DbContextOptionsBuilder<PrestamoContex>()
                        .UseNpgsql(connectionString)
                        .Options;
                    break;
                case "memoriaPrestamo":
                    if (modoVirtual)
                    {
                        opciones = new DbContextOptionsBuilder<PrestamoContex>()
                            .UseInMemoryDatabase(connectionString)
                            .Options;
                    }
                    break;
                default:
                    break;
            }
            return opciones;
        }
    }
}
