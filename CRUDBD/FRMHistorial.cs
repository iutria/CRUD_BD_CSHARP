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
    public partial class FRMHistorial : Form
    {
        private AlquilerService alquilerService;
        private PersonaService personaService;
        private double total = 0;
        public FRMHistorial()
        {
            alquilerService = new AlquilerService();
            personaService = new PersonaService();
            InitializeComponent();
            for (int i = 0; i < 12; i++)
            {
                cmbMes.Items.Insert(i, (i + 1).ToString());
            }
            int yearActual = int.Parse(DateTime.Now.Year.ToString());
            int j = 2000;
            int k = 0;
            while (yearActual >= j)
            {
                cmbYear.Items.Insert(k, j.ToString());
                k++;
                j++;
            }
            CargarEncabezadoDGV();
            CargarDatosDTG();
        }
        private void CargarEncabezadoDGV()
        {
            dtgHistorial.Columns.Add("Placa", "Placa");
            dtgHistorial.Columns.Add("KM", "KM");
            //dtgHistorial.Columns.Add("KMI", "KMI");
            dtgHistorial.Columns.Add("valorKM", "valorKM");
            //dtgHistorial.Columns.Add("Id", "Id");
            dtgHistorial.Columns.Add("Persona", "Persona");
            dtgHistorial.Columns.Add("Fecha", "Fecha");
            dtgHistorial.Columns.Add("Total", "Total");
        }
        private void CargarDatosDTG()
        {
            total = 0;
            dtgHistorial.Rows.Clear();
            foreach (Alquiler alquiler in alquilerService.Alquileres)
            {
                if (alquiler.Estado.Trim() == "inactivo")
                {
                    Persona persona = personaService.ObtenerPersona(alquiler.Persona);
                    dtgHistorial.Rows.Add(alquiler.Vehiculo, alquiler.KM(), alquiler.ValorKM, persona.Nombre, alquiler.Fecha, "$" + alquiler.Total());
                    total += alquiler.Total();
                }

            }
            lblTotal.Text = "$" + total.ToString();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void Filtrar()
        {
            total = 0;
            dtgHistorial.Rows.Clear();
            string opcionMes = cmbMes.Text;
            string opcionYear = cmbYear.Text;
            foreach (Alquiler alquiler in alquilerService.Alquileres)
            {
                if (alquiler.Estado == "inactivo")
                {
                    string mes = alquiler.Fecha.Split('-')[1];
                    string year = alquiler.Fecha.Split('-')[2];
                    if ((opcionMes == mes) && (opcionYear == year))
                    {
                        Persona persona = personaService.ObtenerPersona(alquiler.Persona);
                        dtgHistorial.Rows.Add(alquiler.Vehiculo, alquiler.KM(), alquiler.ValorKM, persona.Nombre, alquiler.Fecha, "$" + alquiler.Total());
                        //dtgHistorial.Rows.Add(alquiler.Vehiculo, alquiler.ValorKM, alquiler.KmInicial, alquiler.KmFinal, persona.Id, persona.Nombre, alquiler.Fecha, "$" + alquiler.Total());
                        total += alquiler.Total();
                    }

                }
            }
            lblTotal.Text = "$" + total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatosDTG();
        }
    }
}
