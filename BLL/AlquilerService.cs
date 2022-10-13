using DAL;
using ENTITY;
using System.Collections.Generic;

namespace BLL
{
    public class AlquilerService
    {
        private AlquilerRepository alquilerRepository;
        public List<Alquiler> Alquileres;
        public AlquilerService()
        {
            alquilerRepository = new AlquilerRepository();
            Alquileres = alquilerRepository.ObtenerAlquileres();
        }
        public void Actualizar()
        {
            Alquileres = alquilerRepository.ObtenerAlquileres();
        }

        public List<string> AgregarAlquiler(Alquiler alquiler, Vehiculo vehiculo)
        {
            List<string> respuesta = new List<string>();
            vehiculo.Estado = "Ocupado";
            VehiculoService vs = new VehiculoService();

            List<string> res= vs.EditarVehiculo(vehiculo);

            if (res[0] != "true")
            {
                respuesta.Add("false");
                respuesta.Add("Ha ocurrido un error al guardar");
                return respuesta;
            }
            PrecioKilometroService pk = new PrecioKilometroService();

            alquiler.ValorKM = pk.PrecioKM;

            bool r = alquilerRepository.Agregar(alquiler);
            if (r)
            {
                respuesta.Add("true");
                respuesta.Add("Agregado correctamente");
            }
            else
            {
                respuesta.Add("false");
                respuesta.Add("Ha ocurrido un error al guardar");
            }
            return respuesta;
        }
        public List<string> EditarAlquiler(Alquiler alquiler)
        {
            List<string> respuesta = new List<string>();
            alquiler.Estado = "inactivo";
            
            bool r = alquilerRepository.Editar(alquiler);
            if (r)
            {
                respuesta.Add("true");
                respuesta.Add("Editado correctamente");
            }
            else
            {
                respuesta.Add("false");
                respuesta.Add("Ha ocurrido un error al Editar");
            }
            return respuesta;
        }

        public Alquiler ObtenerAlquiler(string placa, string id, string fecha,int kmi, string estado)
        {
            foreach (Alquiler alquiler in Alquileres)
            {
                if (alquiler.Vehiculo.Trim() == placa &&
                    alquiler.Persona.Trim() == id && 
                    alquiler.Fecha.Trim() == fecha &&
                    alquiler.KmInicial == kmi &&
                    alquiler.Estado.Trim() == estado)
                {
                    return alquiler;
                }
            }
            return null;
        }

    }
}
