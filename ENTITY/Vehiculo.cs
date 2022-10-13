using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Vehiculo
    {
        //Placa del Vehículo, descripción, kilometraje actual, Estado (Disponible, ocupado)
        public string Placa { get; set; }
        public string Descripcion { get; set; }
        public int KilometrajeAcutal { get; set; }
        public string Estado { get; set; }
        public Vehiculo(string placa, string descripcion, int kilometrajeAcutal,string Estado)
        {
            this.Placa = placa;
            this.Descripcion = descripcion;
            this.KilometrajeAcutal = kilometrajeAcutal;
            this.Estado = Estado;
            if (placa.Length==0)
            {
                throw new Exception();
            }
            if (kilometrajeAcutal<0)
            {
                throw new Exception();
            }
            if (Estado!="Disponible" && Estado != "Ocupado")
            {
                throw new Exception();
            }
        }
        public Vehiculo(DataRow map)
        {
            this.Placa = (string)map[0];
            this.Descripcion = (string)map[1];
            this.KilometrajeAcutal = (int)map[2];
        }
        public string ToMap()
        {
            string d = Descripcion.Length == 0 ? "Sin descripcion" : Descripcion;
            return Placa + ";" + d + ";" + KilometrajeAcutal + ";" + Estado;
        }

    }
}
