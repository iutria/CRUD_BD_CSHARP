using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Alquiler
    {
        public string id { get; set; }
        public string Vehiculo { get; set; }
        public string Persona { get; set; }
        public int KmInicial { get; set; }
        public int KmFinal { get; set; }
        public int ValorKM { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public bool Descuento { get; set; }

        public Alquiler(string vehiculo, string persona, int kmInicial, int kmFinal, int valorKM, string fecha, string estado, bool descuento)
        {
            Vehiculo = vehiculo.Trim();
            Persona = persona.Trim();
            KmInicial = kmInicial;
            KmFinal = kmFinal;
            ValorKM = valorKM;
            Fecha = fecha.Trim();
            Estado = estado.Trim();
            Descuento = descuento;
            id = persona.Trim() + vehiculo.Trim() + fecha.Trim() + kmInicial;
        }

        public string ToMap()
        {
            return Vehiculo + ";" + Persona + ";" + KmInicial + ";" + KmFinal + ";" + ValorKM + ";" + Fecha + ";" + Estado + ";" +Descuento;
        }
        public Alquiler(DataRow map)
        {
            this.Vehiculo = (string)map[0];
            this.Persona = (string)map[1];
            this.KmInicial = Convert.ToInt32(map[2]);
            this.KmFinal = Convert.ToInt32(map[3]);
            this.ValorKM = Convert.ToInt32(map[4]);
            this.Fecha = (string)map[5];
            this.Estado = (string)map[6];
            this.Descuento = (bool)map[7];
            this.id = (string)map[8];
        }
        public double Total()
        {
            if(KmFinal< KmInicial)
            {
                throw new Exception();
            }
            int totalF = ValorKM * (KmFinal - KmInicial); 
            if (Descuento)
            {
                return totalF<=0 ? 0 : (totalF - (totalF * 0.15));
            }
            else
            {
                return totalF;
            }
        }
        public double KM()
        {
            return KmFinal - KmInicial;
        }
    }
}
