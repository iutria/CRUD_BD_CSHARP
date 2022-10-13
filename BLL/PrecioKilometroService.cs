using DAL;

namespace BLL
{
    public class PrecioKilometroService
    {
        private PrecioKilometroRepository _repository;
        public int PrecioKM { get; set; }

        public PrecioKilometroService()
        {
            _repository = new PrecioKilometroRepository();
            PrecioKM = _repository.getPrecioKilometro();
        }
        public void Actualizar()
        {
            PrecioKM = _repository.getPrecioKilometro();
        }
        public bool ModificarPrecioKM(int precio)
        {
            if (precio <= 0)
            {
                return false;
            }
            else
            {
                return _repository.ModificarPrecioKilometro(precio);
            }
        }

    }
}
