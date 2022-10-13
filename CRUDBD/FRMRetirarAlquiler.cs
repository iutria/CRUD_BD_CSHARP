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
    public partial class FRMRetirarAlquiler : Form
    {
        private AlquilerService alquilerService;
        private Alquiler alquiler;
        private Persona persona;
        private bool calculado = false;
        public FRMRetirarAlquiler(Alquiler alquiler, Persona persona)
        {
            alquilerService = new AlquilerService();
            this.alquiler = alquiler;
            this.persona = persona;
            InitializeComponent();
            lblNombre.Text = persona.Nombre;
            lblDescuento.Text = persona.TipoCliente == "OCASIONAL" ? "NO" : "SI";
            lblPlaca.Text = alquiler.Vehiculo;
            lblFecha.Text = alquiler.Fecha;
            lblKMI.Text = alquiler.KmInicial.ToString();
            lblTotal.Text = "$0";
            lblPrecio.Text = "$" + alquiler.ValorKM;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                alquiler.Descuento = persona.TipoCliente != "OCASIONAL";
                alquiler.KmFinal = int.Parse(txtKMF.Text);
                lblTotal.Text = "$" + alquiler.Total();
                calculado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe ingresar correctamente el valor del kilometrage final, verifica que el KM final sea mayor al KM inicial");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (calculado)
            {
                List<string> respuesta = alquilerService.EditarAlquiler(alquiler);
                MessageBox.Show(respuesta[1]);
                if (respuesta[0] == "true")
                {
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("debe calcular el valor total");
            }
        }
    }
}
