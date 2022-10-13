using System;
using System.Collections.Generic;
using System.Data;

namespace ENTITY
{
    public class Persona
    {
        //Id, nombre y tipo de cliente(ocasional, por contratos)
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string TipoCliente { get; set; }
        public List<Alquiler> Alquileres { get; set; }

        public Persona(string id, string nombre, string tipoCliente)
        {
            Id = id;
            Nombre = nombre;
            TipoCliente = tipoCliente;
            if(id.Length == 0 || tipoCliente.Length == 0)
            {
                throw new Exception();
            }
            //if(tipoCliente != "OCASIONAL" && tipoCliente != "CONTRATOS")
            //{
            //    throw new Exception();
            //}
        }

        public Persona(DataRow map)
        {
            this.Id = (string)map[0];
            this.Nombre = (string)map[1];
            this.TipoCliente = (string)map[2];
        }

        public string ToMap()
        {
            return Id + ";" + Nombre + ";" + TipoCliente;
        }
    }
}