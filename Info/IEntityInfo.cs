using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public interface IEntityInfo
    {
        public string Publicar(IDBEntity entidad);

        public string Publicar(IEnumerable<IDBEntity> lista);
    }
}
