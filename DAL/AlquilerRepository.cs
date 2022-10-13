using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class AlquilerRepository
    {
        private string ruta = "Alquileres.txt";
        private ConeccionBD conn = null;
        public AlquilerRepository()
        {
            conn = new ConeccionBD();
        }
        public bool Agregar(Alquiler alquiler)
        {
            string _sql = string.Format("insert into Alquileres (vehiculo,cliente,kmInicial,kmFinal,ValorKM,Fecha,Estado,Descuento,id) values ('{0}', '{1}', {2}, {3}, {4},'{5}','{6}',{7},'{8}')",
                alquiler.Vehiculo, alquiler.Persona, alquiler.KmInicial, alquiler.KmFinal,alquiler.ValorKM, alquiler.Fecha, alquiler.Estado, alquiler.Descuento?1:0,alquiler.id);
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public bool SobreEscribir(List<Alquiler> alquileres)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);
                foreach (Alquiler alquiler in alquileres)
                {
                    escritor.WriteLine(alquiler.ToMap());
                }
                escritor.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Editar(Alquiler alquiler)
        {
            string _sql = string.Format("update Alquileres set kmFinal={0}, Estado='{1}' where id = '{2}'", alquiler.KmFinal, alquiler.Estado, alquiler.id);
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public List<Alquiler> ObtenerAlquileres()
        {
            string _sql = "select * from Alquileres";
            System.Data.DataTable tabla = new DataTable("Alquileres");
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conn.Conexion);

            adapter.Fill(tabla);

            List<Alquiler> lista = new List<Alquiler>();

            foreach (var fila in tabla.Rows)
            {
                lista.Add(new Alquiler((DataRow)fila));
            }
            return lista;
        }
    }
}
