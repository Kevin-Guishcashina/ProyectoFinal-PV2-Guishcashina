using Modelo;
using Modelo.ControlPrestamo;
using System;
using System.Collections.Generic;

namespace Info
{
    public class ClienteInfo :EntityInfo
    {
        public static new string Publicar(IDBEntity entity)
        {
            var cliente = (Cliente)entity;
            return String.Format(
                "ClienteID: {0} \n Nombres y Apellidos: {1} {2} \n Edad: {3} \n Genero {4} \n Telefono {5} \n Direccion {6}",
                cliente.ClienteId,
                cliente.Nombres,
                cliente.Apellidos,
                cliente.edad,
                cliente.Genero,
                cliente.Telefono,
                cliente.Direccion

            );
        }

        public static new string Publicar(IEnumerable<IDBEntity> entity)
        {
            var clientes = (List<Cliente>)entity;
            string msj = "ClienteId \t Nombre y Apellidos \t edad \t genero \t telefono \t direccion \n";
            foreach (var cliente in clientes)
            {
                msj += String.Format(
                    "{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \n",
                    cliente.ClienteId,
                    cliente.Nombres,
                    cliente.Apellidos,
                    cliente.edad,
                    cliente.Genero,
                    cliente.Telefono,
                    cliente.Direccion
                    );
            }
            return msj;
        }
    }
}
