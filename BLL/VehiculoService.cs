using DAL;
using ENTITY;
using System.Collections.Generic;

namespace BLL
{
    public class VehiculoService
    {
        private VehiculoRepository _repository;
        public List<Vehiculo> vehiculos;
        public VehiculoService()
        {
            _repository = new VehiculoRepository();
            vehiculos = _repository.obtenerVehiculos();
        }
        public void Actualizar()
        {
            vehiculos = _repository.obtenerVehiculos();
        }
        public List<string> AgregarVehiculo(Vehiculo vehiculo)
        {
            List<string> respuesta = new List<string>();
            bool r = _repository.Agregar(vehiculo);
            if (ObtenerVehiculo(vehiculo.Placa) != null)
            {
                respuesta.Add("false");
                respuesta.Add("Ya este vehiculo esta registrado");
                return respuesta;
            }
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
        public List<string> EditarVehiculo(Vehiculo vehiculo)
        {
            List<string> respuesta = new List<string>();
            bool r = _repository.Editar(vehiculo);
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
        public List<string> EliminarVehiculo(string placa)
        {
            List<string> respuesta = new List<string>();
            Vehiculo vehiculo = ObtenerVehiculo(placa);
            if (vehiculo == null)
            {
                respuesta.Add("false");
                respuesta.Add("Ha ocurrido un error");
                return respuesta;
            }
            if (vehiculo.Estado == "Ocupado")
            {
                respuesta.Add("false");
                respuesta.Add("No puedes borrar este vehiculo");
                return respuesta;
            }
            bool r = _repository.Eliminar(placa);
            if (r)
            {
                respuesta.Add("true");
                respuesta.Add("Eliminado correctamente");
            }
            else
            {
                respuesta.Add("false");
                respuesta.Add("Ha ocurrido un error al Eliminar");
            }
            return respuesta;
        }
        public Vehiculo ObtenerVehiculo(string placa)
        {
            foreach (Vehiculo vehiculo in vehiculos)
            {
                if (vehiculo.Placa == placa)
                {
                    return vehiculo;
                }
            }
            return null;
        }
        public List<Vehiculo> ObtenerVehiculosDisponibles()
        {
            //List<Vehiculo> disponibles = new List<Vehiculo>();
            //foreach (Vehiculo vehiculo in vehiculos)
            //{
            //    if (vehiculo.Estado == "Disponible")
            //    {
            //        disponibles.Add(vehiculo);
            //    }
            //}
            //return disponibles;
            return vehiculos;
        }
    }
}
