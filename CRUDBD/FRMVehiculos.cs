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
    public partial class FRMVehiculos : Form
    {
        public FRMVehiculos()
        {
            _vehiculoService = new VehiculoService();
            InitializeComponent();
            CargarEncabezadoDGV();
            CargarDatosDTG();
        }
        private VehiculoService _vehiculoService;

        private void CargarEncabezadoDGV()
        {
            dtgVehiculos.Columns.Add("Placa", "Placa");
            dtgVehiculos.Columns.Add("Descripción", "Descripcion");
            dtgVehiculos.Columns.Add("Kilometrage", "Kilometrage");
            //dtgVehiculos.Columns.Add("Estado", "Estado");
            dtgVehiculos.Columns.Add("Editar", "Editar");
            dtgVehiculos.Columns.Add("Eliminar", "Eliminar");
        }
        private void CargarDatosDTG()
        {
            dtgVehiculos.Rows.Clear();
            foreach (Vehiculo vehiculo in _vehiculoService.vehiculos)
            {
                dtgVehiculos.Rows.Add(vehiculo.Placa, vehiculo.Descripcion, vehiculo.KilometrajeAcutal, "Editar", "Eliminar");
            }
        }
        private void AgregarVehiculo()
        {
            try
            {
                Vehiculo vehiculo = new Vehiculo(txtPlaca.Text, txtDescripcion.Text, int.Parse(txtKilometrage.Text), cmbEstado.Text);
                List<string> respuesta = _vehiculoService.AgregarVehiculo(vehiculo);
                MessageBox.Show(respuesta[1]);
                if (respuesta[0] == "true")
                {
                    _vehiculoService.Actualizar();
                    CargarDatosDTG();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("verifique que los datos ingresados sean valido");
            }
        }
        private void EditarVehiculo()
        {
            try
            {
                Vehiculo vehiculo = new Vehiculo(txtPlaca.Text, txtDescripcion.Text, int.Parse(txtKilometrage.Text), "Disponible");
                List<string> respuesta = _vehiculoService.EditarVehiculo(vehiculo);
                MessageBox.Show(respuesta[1]);
                if (respuesta[0] == "true")
                {
                    _vehiculoService.Actualizar();
                    CargarDatosDTG();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("verifique que los datos ingresados sean valido");
            }
        }
        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (btnAccion.Text == "Agregar")
            {
                AgregarVehiculo();
            }
            else
            {
                EditarVehiculo();
            }
        }
        private void Limpiar()
        {
            txtDescripcion.Text = "";
            txtKilometrage.Text = "";
            txtPlaca.Text = "";
            cmbEstado.Text = "Disponible";
            btnAccion.Text = "Agregar";
            txtPlaca.Enabled = true;
        }

        private void dtgVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = this.dtgVehiculos.Rows[e.RowIndex];
                if (e.ColumnIndex == 4)
                {
                    MessageBox.Show("" + row.Cells["Placa"].Value.ToString());
                }
            }
        }


        private void SeleccionarVehiculo(string placa)
        {
            Vehiculo vehiculo = _vehiculoService.ObtenerVehiculo(placa);
            if (vehiculo == null)
            {
                return;
            }
            else
            {
                txtPlaca.Text = vehiculo.Placa.Trim();
                txtDescripcion.Text = vehiculo.Descripcion;
                txtKilometrage.Text = vehiculo.KilometrajeAcutal.ToString();
                cmbEstado.Text = vehiculo.Estado;
                btnAccion.Text = "Editar";
                txtPlaca.Enabled = false;
            }
        }
        private void EliminarVehiculo(string placa)
        {
            DialogResult result = MessageBox.Show("Seguro que dese Eliminar este vehiculo de placa " + placa + "?", "Eliminar", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                List<string> respuesta = _vehiculoService.EliminarVehiculo(placa);
                MessageBox.Show(respuesta[1]);
                if (respuesta[0] == "true")
                {
                    _vehiculoService.Actualizar();
                    CargarDatosDTG();
                    Limpiar();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            dtgVehiculos.Rows.Clear();
            foreach (Vehiculo vehiculo in _vehiculoService.vehiculos)
            {
                if (vehiculo.Placa.Contains(txtBuscar.Text))
                {
                    dtgVehiculos.Rows.Add(vehiculo.Placa, vehiculo.Descripcion, vehiculo.KilometrajeAcutal, "Editar", "Eliminar");
                }

            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void dtgVehiculos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgVehiculos.Rows[e.RowIndex];
                if (e.ColumnIndex == 3)
                {
                    SeleccionarVehiculo(row.Cells["Placa"].Value.ToString());
                }
                if (e.ColumnIndex == 4)
                {
                    EliminarVehiculo(row.Cells["Placa"].Value.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
