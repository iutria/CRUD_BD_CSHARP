using DAL;
using ENTITY;
using System.Collections.Generic;

namespace BLL
{
    public class PersonaService
    {
        private PersonaRepository personaRepository;
        private AlquilerService alquilerService;
        public List<Persona> personas;
        private List<Alquiler> alquileres;
        public PersonaService()
        {
            alquilerService = new AlquilerService();
            alquileres = alquilerService.Alquileres;
            personaRepository = new PersonaRepository();
            personas = personaRepository.obtenerPersonas();
            Actualizar();
        }
        public void Actualizar()
        {
            alquileres = alquilerService.Alquileres;
            personas = personaRepository.obtenerPersonas();
            foreach (Persona persona in personas)
            {
                persona.Alquileres = ObtenerAlquileresPersona(persona.Id);
            }
        }
        private List<Alquiler> ObtenerAlquileresPersona(string id)
        {
            List<Alquiler> alquiles = new List<Alquiler>();
            foreach(Alquiler alquiler in alquileres)
            {
                if(alquiler.Persona == id)
                {
                    alquiles.Add(alquiler);
                }
            }
            return alquiles;
        }
        public List<string> AgregarPersona(Persona persona)
        {
            List<string> respuesta = new List<string>();
            if (ObtenerPersona(persona.Id) != null)
            {
                respuesta.Add("false");
                respuesta.Add("Ya esta persona esta registrada");
                return respuesta;
            }
            bool r = personaRepository.Agregar(persona);
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
        public List<string> EditarPersona(Persona persona)
        {
            List<string> respuesta = new List<string>();
            bool r = personaRepository.Editar(persona);
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
        public List<string> EliminarPersona(string id)
        {
            List<string> respuesta = new List<string>();
            Persona persona = ObtenerPersona(id);
            if (persona == null)
            {
                respuesta.Add("false");
                respuesta.Add("Ha ocurrido un error");
                return respuesta;
            }
            if (persona.Alquileres.Count>0)
            {
                respuesta.Add("false");
                respuesta.Add("No puedes borrar esta persona");
                return respuesta;
            }
            bool r = personaRepository.Eliminar(id);
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
        public Persona ObtenerPersona(string id)
        {
            foreach (Persona persona in personas)
            {
                if (persona.Id.Trim() == id.Trim())
                {
                    return persona;
                }
            }
            return null;
        }

    }
}