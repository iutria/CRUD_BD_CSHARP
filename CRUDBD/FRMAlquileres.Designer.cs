namespace CRUDBD
{
    partial class FRMAlquileres
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgVehiculos = new System.Windows.Forms.DataGridView();
            this.btnAccion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgVehiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgVehiculos
            // 
            this.dtgVehiculos.AllowUserToAddRows = false;
            this.dtgVehiculos.AllowUserToDeleteRows = false;
            this.dtgVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgVehiculos.Location = new System.Drawing.Point(12, 12);
            this.dtgVehiculos.Name = "dtgVehiculos";
            this.dtgVehiculos.Size = new System.Drawing.Size(676, 305);
            this.dtgVehiculos.TabIndex = 10;
            this.dtgVehiculos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgVehiculos_CellClick);
            // 
            // btnAccion
            // 
            this.btnAccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccion.Location = new System.Drawing.Point(463, 323);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(225, 34);
            this.btnAccion.TabIndex = 11;
            this.btnAccion.Text = "Agregar";
            this.btnAccion.UseVisualStyleBackColor = true;
            this.btnAccion.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRMAlquileres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 369);
            this.Controls.Add(this.btnAccion);
            this.Controls.Add(this.dtgVehiculos);
            this.Name = "FRMAlquileres";
            this.Text = "FRMAlquileres";
            ((System.ComponentModel.ISupportInitialize)(this.dtgVehiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgVehiculos;
        private System.Windows.Forms.Button btnAccion;
    }
}