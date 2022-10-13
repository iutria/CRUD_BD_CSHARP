using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class ConeccionBD
    {
        public SqlConnection Conexion;
        public ConeccionBD()
        {
            Conexion = new SqlConnection("Server=;DataBase=RentCar;Integrated Security=true");
        }
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
