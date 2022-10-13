using System;
using System.IO;

namespace DAL
{
    public class PrecioKilometroRepository
    {
        private string ruta = "PrecioKilometro.txt";
        public bool ModificarPrecioKilometro(int precio)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, false);
                escritor.WriteLine(precio);
                escritor.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CrearArchivo()
        {
            try
            {
                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(0);
                escritor.Close();
            }
            catch (Exception)
            {}
        }
        public int getPrecioKilometro()
        {
            int precio = 0;
            StreamReader lector;
            try
            {
                lector = new StreamReader(ruta);
                string linea = string.Empty;
                while (!lector.EndOfStream)
                {
                    linea = lector.ReadLine();
                    precio = int.Parse(linea);
                    if (precio<0)
                    {
                        return 0;
                    }
                }
                lector.Close();
            }
            catch (Exception e) 
            {
                CrearArchivo();
            }
            return precio;
        }
    }
}
