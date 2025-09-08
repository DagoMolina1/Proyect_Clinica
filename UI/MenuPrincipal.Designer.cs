namespace ClinicaIPS_U.UI
{
    partial class MenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procedimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudasDiagnósticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenMedicamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenProcedimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenAyudasDiagnósticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pacientesToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.medicamentosToolStripMenuItem,
            this.procedimientosToolStripMenuItem,
            this.ayudasDiagnósticasToolStripMenuItem,
            this.facturaciónToolStripMenuItem,
            this.ordenesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pacientesToolStripMenuItem
            // 
            this.pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            this.pacientesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.pacientesToolStripMenuItem.Text = "Pacientes";
            this.pacientesToolStripMenuItem.Click += new System.EventHandler(this.pacientesToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // medicamentosToolStripMenuItem
            // 
            this.medicamentosToolStripMenuItem.Name = "medicamentosToolStripMenuItem";
            this.medicamentosToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.medicamentosToolStripMenuItem.Text = "Medicamentos";
            this.medicamentosToolStripMenuItem.Click += new System.EventHandler(this.medicamentosToolStripMenuItem_Click);
            // 
            // procedimientosToolStripMenuItem
            // 
            this.procedimientosToolStripMenuItem.Name = "procedimientosToolStripMenuItem";
            this.procedimientosToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.procedimientosToolStripMenuItem.Text = "Procedimientos";
            this.procedimientosToolStripMenuItem.Click += new System.EventHandler(this.procedimientosToolStripMenuItem_Click);
            // 
            // ayudasDiagnósticasToolStripMenuItem
            // 
            this.ayudasDiagnósticasToolStripMenuItem.Name = "ayudasDiagnósticasToolStripMenuItem";
            this.ayudasDiagnósticasToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.ayudasDiagnósticasToolStripMenuItem.Text = "Ayudas Diagnósticas";
            this.ayudasDiagnósticasToolStripMenuItem.Click += new System.EventHandler(this.ayudasDiagnósticasToolStripMenuItem_Click);
            // 
            // facturaciónToolStripMenuItem
            // 
            this.facturaciónToolStripMenuItem.Name = "facturaciónToolStripMenuItem";
            this.facturaciónToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.facturaciónToolStripMenuItem.Text = "Facturación";
            this.facturaciónToolStripMenuItem.Click += new System.EventHandler(this.facturaciónToolStripMenuItem_Click);
            // 
            // ordenesToolStripMenuItem
            // 
            this.ordenesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordenGeneralToolStripMenuItem,
            this.ordenMedicamentosToolStripMenuItem,
            this.ordenProcedimientosToolStripMenuItem,
            this.ordenAyudasDiagnósticasToolStripMenuItem});
            this.ordenesToolStripMenuItem.Name = "ordenesToolStripMenuItem";
            this.ordenesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.ordenesToolStripMenuItem.Text = "Órdenes";
            // 
            // ordenGeneralToolStripMenuItem
            // 
            this.ordenGeneralToolStripMenuItem.Name = "ordenGeneralToolStripMenuItem";
            this.ordenGeneralToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ordenGeneralToolStripMenuItem.Text = "Orden General";
            this.ordenGeneralToolStripMenuItem.Click += new System.EventHandler(this.ordenGeneralToolStripMenuItem_Click);
            // 
            // ordenMedicamentosToolStripMenuItem
            // 
            this.ordenMedicamentosToolStripMenuItem.Name = "ordenMedicamentosToolStripMenuItem";
            this.ordenMedicamentosToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ordenMedicamentosToolStripMenuItem.Text = "Orden Medicamentos";
            this.ordenMedicamentosToolStripMenuItem.Click += new System.EventHandler(this.ordenMedicamentosToolStripMenuItem_Click);
            // 
            // ordenProcedimientosToolStripMenuItem
            // 
            this.ordenProcedimientosToolStripMenuItem.Name = "ordenProcedimientosToolStripMenuItem";
            this.ordenProcedimientosToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ordenProcedimientosToolStripMenuItem.Text = "Orden Procedimientos";
            this.ordenProcedimientosToolStripMenuItem.Click += new System.EventHandler(this.ordenProcedimientosToolStripMenuItem_Click);
            // 
            // ordenAyudasDiagnósticasToolStripMenuItem
            // 
            this.ordenAyudasDiagnósticasToolStripMenuItem.Name = "ordenAyudasDiagnósticasToolStripMenuItem";
            this.ordenAyudasDiagnósticasToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.ordenAyudasDiagnósticasToolStripMenuItem.Text = "Orden Ayudas Diagnósticas";
            this.ordenAyudasDiagnósticasToolStripMenuItem.Click += new System.EventHandler(this.ordenAyudasDiagnósticasToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procedimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudasDiagnósticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenMedicamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenProcedimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordenAyudasDiagnósticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}