using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ControlPrestamo
{
    public class Cliente : IDBEntity
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int edad { get; set; }
        public string Genero { get; set; }
        public int Telefono { get; set; }

        public string Direccion { get; set; }

        public List<Credito> Credito { get; set; }
    }
}
