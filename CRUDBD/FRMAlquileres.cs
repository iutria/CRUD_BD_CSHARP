using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;
namespace CRUDBD
{
    public partial class FRMAlquileres : Form
    {
        private string fecha = "";
        private VehiculoService vehiculoService;
        private string id;
        private int ValorKM = 0;
        private AlquilerService alquilerService;
        private Vehiculo vehiculo = null;
        public FRMAlquileres(string id)
        {
            this.id = id;
            vehiculoService = new VehiculoService();
            alquilerService = new AlquilerService();
            InitializeComponent();
            fecha = DateTime.Now.Date.Day.ToString() + "-" + DateTime.Now.Date.Month.ToString() + "-" + DateTime.Now.Date.Year.ToString();
            CargarEncabezadoDGV();
            CargarDatosDTG();
        }
        private void CargarEncabezadoDGV()
        {
            dtgVehiculos.Columns.Add("Placa", "Placa");
            dtgVehiculos.Columns.Add("Descripción", "Descripcion");
            dtgVehiculos.Columns.Add("Kilometrage", "Kilometrage");
        }
        private void CargarDatosDTG()
        {
            dtgVehiculos.Rows.Clear();
            foreach (Vehiculo vehiculo in vehiculoService.ObtenerVehiculosDisponibles())
            {
                dtgVehiculos.Rows.Add(vehiculo.Placa, vehiculo.Descripcion, vehiculo.KilometrajeAcutal);
            }
        }

        private void AgregarAlquiler()
        {
            Alquiler alquiler = new Alquiler(vehiculo.Placa, id, vehiculo.KilometrajeAcutal, 0, ValorKM, fecha, "activo", false);
            List<string> respuesta = alquilerService.AgregarAlquiler(alquiler, vehiculo);
            MessageBox.Show(respuesta[1]);
            if (respuesta[0] == "true")
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vehiculo != null)
            {
                AgregarAlquiler();
            }
            else
            {
                MessageBox.Show("debe seleccionar un vehiculo");
            }
        }
        private void dtgVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgVehiculos.Rows[e.RowIndex];
                vehiculo = vehiculoService.ObtenerVehiculo(row.Cells["Placa"].Value.ToString());
            }
        }
    }
}
