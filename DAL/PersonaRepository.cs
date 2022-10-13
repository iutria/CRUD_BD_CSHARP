using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class PersonaRepository
    {
        private string ruta = "Personas.txt";
        private ConeccionBD conn = null;
        public PersonaRepository()
        {
            conn = new ConeccionBD();
        }
        public bool Agregar(Persona persona)
        {
            string _sql = string.Format("insert into Clientes (IdCliente,Nombres,TipoCliente) values ('{0}', '{1}', '{2}')", persona.Id, persona.Nombre, persona.TipoCliente);
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public bool Editar(Persona persona)
        {
            string _sql = string.Format("update Clientes set Nombres='{1}', TipoCliente='{2}' where IdCliente = '{0}'", persona.Id, persona.Nombre, persona.TipoCliente);
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public bool Eliminar(string id)
        {
            string _sql = string.Format("DELETE FROM Clientes where IdCliente = '{0}'", id);
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public List<Persona> obtenerPersonas()
        {
            string _sql = "select * from Clientes";
            System.Data.DataTable tabla = new DataTable("Clientes");
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conn.Conexion);

            adapter.Fill(tabla);

            List<Persona> lista = new List<Persona>();

            foreach (var fila in tabla.Rows)
            {
                lista.Add(new Persona((DataRow)fila));
            }
            return lista;
        }
    }
}