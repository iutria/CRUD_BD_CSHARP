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
    public partial class FRMPersonas : Form
    {
        public FRMPersonas()
        {
            personaService = new PersonaService();
            InitializeComponent();
            CargarEncabezadoDGV();
            CargarDatosDTG();
        }
        private PersonaService personaService;
        private void CargarEncabezadoDGV()
        {
            dtgPersonas.Columns.Add("Id", "Id");
            dtgPersonas.Columns.Add("Nombre", "Nombre");
            dtgPersonas.Columns.Add("Tipo", "Tipo");
            dtgPersonas.Columns.Add("Editar", "Editar");
            dtgPersonas.Columns.Add("Eliminar", "Eliminar");
            dtgPersonas.Columns.Add("AgregarAlquiler", "AgregarAlquiler");
            dtgPersonas.Columns.Add("Cantidad", "Cantidad");
        }
        private void CargarDatosDTG()
        {
            dtgPersonas.Rows.Clear();
            foreach (Persona persona in personaService.personas)
            {
                dtgPersonas.Rows.Add(persona.Id, persona.Nombre, persona.TipoCliente, "Editar", "Eliminar","Agregar", persona.Alquileres.Count);
            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (btnAccion.Text == "Agregar")
            {
                AgregarPersona();
            }
            else
            {
                EditarPersona();
            }
        }
        private void AgregarPersona()
        {
            try
            {
                Persona persona = new Persona(txtId.Text.Trim(), txtNombre.Text.Trim(), cmbTipo.Text.Trim());
                List<string> respuesta = personaService.AgregarPersona(persona);
                MessageBox.Show(respuesta[1]);
                if (respuesta[0] == "true")
                {
                    personaService.Actualizar();
                    CargarDatosDTG();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("verifique que los datos ingresados sean valido");
            }
        }
        private void EditarPersona()
        {
            try
            {
                Persona persona = new Persona(txtId.Text.Trim(), txtNombre.Text.Trim(), cmbTipo.Text.Trim());
                List<string> respuesta = personaService.EditarPersona(persona);
                MessageBox.Show(respuesta[1]);
                if (respuesta[0] == "true")
                {
                    personaService.Actualizar();
                    CargarDatosDTG();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("verifique que los datos ingresados sean valido");
            }
        }
        private void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            cmbTipo.Text = "OCASIONAL";
            btnAccion.Text = "Agregar";
            txtId.Enabled = true;
        }

        private void dtgPersonas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgPersonas.Rows[e.RowIndex];
                if (e.ColumnIndex == 3)
                {
                    SeleccionarPersona(row.Cells["Id"].Value.ToString().Trim());
                }
                if (e.ColumnIndex == 4)
                {
                    EliminarPersona(row.Cells["Id"].Value.ToString().Trim());
                }
                if (e.ColumnIndex == 5)
                {
                    FRMAlquileres testDialog = new FRMAlquileres(row.Cells["Id"].Value.ToString());
                    testDialog.ShowDialog(this);
                    testDialog.Dispose();
                }
            }
        }
        private void SeleccionarPersona(string id)
        {
            Persona persona = personaService.ObtenerPersona(id);
            if (persona == null)
            {
                return;
            }
            else
            {
                txtId.Text = persona.Id;
                txtNombre.Text = persona.Nombre;
                cmbTipo.Text = persona.TipoCliente.ToString().Trim().ToUpper();
                btnAccion.Text = "Editar";
                txtId.Enabled = false;
            }
        }
        private void EliminarPersona(string placa)
        {
            DialogResult result = MessageBox.Show("Seguro que dese Eliminar esta persona " + placa + "?", "Eliminar", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                List<string> respuesta = personaService.EliminarPersona(placa);
                MessageBox.Show(respuesta[1]);
                if (respuesta[0] == "true")
                {
                    personaService.Actualizar();
                    CargarDatosDTG();
                    Limpiar();
                }
            }
        }

        private void Buscar()
        {
            dtgPersonas.Rows.Clear();
            foreach (Persona persona in personaService.personas)
            {
                if (persona.Id.Contains(txtBuscar.Text))
                {
                    dtgPersonas.Rows.Add(persona.Id, persona.Nombre, persona.TipoCliente, "Editar", "Eliminar","Agregar",persona.Alquileres.Count);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            Buscar();
        }
    }
}
