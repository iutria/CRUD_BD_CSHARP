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
    public partial class FRMRetirar : Form
    {
        private AlquilerService _alquilerService;
        private PersonaService _personaService;
        public FRMRetirar()
        {
            _alquilerService = new AlquilerService();
            _personaService = new PersonaService();
            InitializeComponent();
            CargarEncabezadoDGV();
            CargarDatosDTG();
        }
        private void CargarEncabezadoDGV()
        {
            dtgAlquiler.Columns.Add("Placa", "Placa");
            dtgAlquiler.Columns.Add("ValorKM", "ValorKM");
            dtgAlquiler.Columns.Add("KMI", "KMI");
            dtgAlquiler.Columns.Add("Id", "Id");
            dtgAlquiler.Columns.Add("Persona", "Persona");
            dtgAlquiler.Columns.Add("Fecha", "Fecha");
            dtgAlquiler.Columns.Add("Retirar", "Retirar");
        }
        private void CargarDatosDTG()
        {
            dtgAlquiler.Rows.Clear();
            foreach (Alquiler alquiler in _alquilerService.Alquileres)
            {
                if (alquiler.Estado.Trim() == "activo")
                {
                    Persona persona = _personaService.ObtenerPersona(alquiler.Persona);
                    dtgAlquiler.Rows.Add(alquiler.Vehiculo, alquiler.ValorKM, alquiler.KmInicial, persona.Id, persona.Nombre, alquiler.Fecha, "Retirar");
                }

            }
        }

        private void dtgVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgAlquiler.Rows[e.RowIndex];
                if (e.ColumnIndex == 6)
                {
                    Alquiler alquiler = _alquilerService.ObtenerAlquiler(row.Cells["Placa"].Value.ToString().Trim(), row.Cells["Id"].Value.ToString().Trim(), row.Cells["Fecha"].Value.ToString().Trim(), int.Parse(row.Cells["KMI"].Value.ToString().Trim()), "activo");

                    if (alquiler != null)
                    {
                        Persona persona = _personaService.ObtenerPersona(alquiler.Persona);
                        FRMRetirarAlquiler testDialog = new FRMRetirarAlquiler(alquiler, persona);
                        testDialog.ShowDialog(this);
                        _alquilerService.Actualizar();
                        CargarDatosDTG();
                        testDialog.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error");
                    }
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            dtgAlquiler.Rows.Clear();
            foreach (Alquiler alquiler in _alquilerService.Alquileres)
            {
                if (alquiler.Vehiculo.Contains(txtBuscar.Text))
                {
                    if (alquiler.Estado == "activo")
                    {
                        Persona persona = _personaService.ObtenerPersona(alquiler.Persona);
                        dtgAlquiler.Rows.Add(alquiler.Vehiculo, alquiler.ValorKM, alquiler.KmInicial, persona.Id, persona.Nombre, alquiler.Fecha, "Retirar");
                    }
                }

            }
        }
    }
}
