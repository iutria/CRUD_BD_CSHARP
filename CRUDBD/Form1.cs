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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            AbrirForm(new FRMBienvenida());
        }
        private void AbrirForm(Form Frm)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);
            Form fh = Frm as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Contenedor.Controls.Add(fh);
            this.Contenedor.Tag = fh;
            fh.Show();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new FRMVehiculos());
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new FRMPersonas());
        }

        private void retirarAlquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new FRMRetirar());
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new FRMBienvenida());
        }

        private void editarPrecioKmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMPrecioKM testDialog = new FRMPrecioKM();
            testDialog.ShowDialog(this);
            testDialog.Dispose();
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirForm(new FRMHistorial());
        }
    }
}
