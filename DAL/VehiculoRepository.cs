using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class VehiculoRepository
    {
        private string ruta = "Vehiculos.txt";
        private ConeccionBD conn = null;
        public VehiculoRepository()
        {
            conn = new ConeccionBD();
        }
        public bool Agregar(Vehiculo vehiculo)
        {
            string _sql = string.Format("insert into Vehiculos (Placa, Marca, KilometrajeActual) values ('{0}', '{1}', {2})", vehiculo.Placa, vehiculo.Descripcion, vehiculo.KilometrajeAcutal);
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public bool Editar(Vehiculo vehiculo)
        {
            string _sql = string.Format("update Vehiculos set Marca='{1}', KilometrajeActual={2} where placa = '{0}'", vehiculo.Placa, vehiculo.Descripcion, vehiculo.KilometrajeAcutal);
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public bool Eliminar(string placa)
        {
            string _sql = string.Format("DELETE FROM Vehiculos where placa = '{0}'", placa);
            var cmd = new SqlCommand(_sql, conn.Conexion);
            conn.AbrirConexion();
            int filas = cmd.ExecuteNonQuery();
            conn.CerrarConexion();
            return filas == 1;
        }
        public List<Vehiculo> obtenerVehiculos()
        {
            string _sql = "select * from Vehiculos";
            System.Data.DataTable tabla = new DataTable("vehiculos");
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conn.Conexion);

            adapter.Fill(tabla);

            List<Vehiculo> lista = new List<Vehiculo>();

            foreach (var fila in tabla.Rows)
            {
                lista.Add(new Vehiculo((DataRow)fila));
            }
            return lista;
        }
    }
}
