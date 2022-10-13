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
    public partial class FRMPrecioKM : Form
    {
        private PrecioKilometroService _service;
        public FRMPrecioKM()
        {
            _service = new PrecioKilometroService();
            InitializeComponent();
            txtPrecio.Text = _service.PrecioKM.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Actualizar();
            }
        }

        private void Actualizar()
        {
            try
            {
                int precio = int.Parse(txtPrecio.Text);
                bool respuesta = _service.ModificarPrecioKM(precio);
                if (respuesta)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al modificar el Precio, verifique que el valor sea un numero positivo, o intente nuevamente", "error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No puedes ingresar texto en un campo numerico", "error");
            }
        }
    }
}
