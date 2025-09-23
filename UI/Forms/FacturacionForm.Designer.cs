namespace ClinicaIPS_U.UI
{
    partial class FacturacionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdOrden = new System.Windows.Forms.TextBox();
            this.chkRegistrar = new System.Windows.Forms.CheckBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.groupBoxPaciente = new System.Windows.Forms.GroupBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxSeguro = new System.Windows.Forms.GroupBox();
            this.txtEstadoPoliza = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFechaFin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiasVigencia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPoliza = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAseguradora = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxResumen = new System.Windows.Forms.GroupBox();
            this.txtValorAseguradora = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtValorPaciente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalServicios = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCopago = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMedico = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lstDetalle = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBoxPaciente.SuspendLayout();
            this.groupBoxSeguro.SuspendLayout();
            this.groupBoxResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de orden:";
            // 
            // txtIdOrden
            // 
            this.txtIdOrden.Location = new System.Drawing.Point(125, 17);
            this.txtIdOrden.Name = "txtIdOrden";
            this.txtIdOrden.Size = new System.Drawing.Size(120, 20);
            this.txtIdOrden.TabIndex = 1;
            // 
            // chkRegistrar
            // 
            this.chkRegistrar.AutoSize = true;
            this.chkRegistrar.Location = new System.Drawing.Point(260, 19);
            this.chkRegistrar.Name = "chkRegistrar";
            this.chkRegistrar.Size = new System.Drawing.Size(123, 17);
            this.chkRegistrar.TabIndex = 2;
            this.chkRegistrar.Text = "Registrar en sistema";
            this.chkRegistrar.UseVisualStyleBackColor = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(399, 14);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 25);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // groupBoxPaciente
            // 
            this.groupBoxPaciente.Controls.Add(this.txtEdad);
            this.groupBoxPaciente.Controls.Add(this.label5);
            this.groupBoxPaciente.Controls.Add(this.txtCedula);
            this.groupBoxPaciente.Controls.Add(this.label4);
            this.groupBoxPaciente.Controls.Add(this.txtPaciente);
            this.groupBoxPaciente.Controls.Add(this.label3);
            this.groupBoxPaciente.Location = new System.Drawing.Point(21, 55);
            this.groupBoxPaciente.Name = "groupBoxPaciente";
            this.groupBoxPaciente.Size = new System.Drawing.Size(478, 100);
            this.groupBoxPaciente.TabIndex = 4;
            this.groupBoxPaciente.TabStop = false;
            this.groupBoxPaciente.Text = "Datos del paciente";
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(376, 59);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(80, 20);
            this.txtEdad.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Edad";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(83, 59);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.ReadOnly = true;
            this.txtCedula.Size = new System.Drawing.Size(235, 20);
            this.txtCedula.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cédula";
            // 
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(83, 26);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(373, 20);
            this.txtPaciente.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Paciente";
            // 
            // groupBoxSeguro
            // 
            this.groupBoxSeguro.Controls.Add(this.txtEstadoPoliza);
            this.groupBoxSeguro.Controls.Add(this.label10);
            this.groupBoxSeguro.Controls.Add(this.txtFechaFin);
            this.groupBoxSeguro.Controls.Add(this.label9);
            this.groupBoxSeguro.Controls.Add(this.txtDiasVigencia);
            this.groupBoxSeguro.Controls.Add(this.label8);
            this.groupBoxSeguro.Controls.Add(this.txtPoliza);
            this.groupBoxSeguro.Controls.Add(this.label7);
            this.groupBoxSeguro.Controls.Add(this.txtAseguradora);
            this.groupBoxSeguro.Controls.Add(this.label6);
            this.groupBoxSeguro.Location = new System.Drawing.Point(21, 161);
            this.groupBoxSeguro.Name = "groupBoxSeguro";
            this.groupBoxSeguro.Size = new System.Drawing.Size(478, 126);
            this.groupBoxSeguro.TabIndex = 5;
            this.groupBoxSeguro.TabStop = false;
            this.groupBoxSeguro.Text = "Seguro médico";
            // 
            // txtEstadoPoliza
            // 
            this.txtEstadoPoliza.Location = new System.Drawing.Point(349, 26);
            this.txtEstadoPoliza.Name = "txtEstadoPoliza";
            this.txtEstadoPoliza.ReadOnly = true;
            this.txtEstadoPoliza.Size = new System.Drawing.Size(107, 20);
            this.txtEstadoPoliza.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(279, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Estado póliza";
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Location = new System.Drawing.Point(349, 91);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.ReadOnly = true;
            this.txtFechaFin.Size = new System.Drawing.Size(107, 20);
            this.txtFechaFin.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Vigencia hasta";
            // 
            // txtDiasVigencia
            // 
            this.txtDiasVigencia.Location = new System.Drawing.Point(139, 91);
            this.txtDiasVigencia.Name = "txtDiasVigencia";
            this.txtDiasVigencia.ReadOnly = true;
            this.txtDiasVigencia.Size = new System.Drawing.Size(120, 20);
            this.txtDiasVigencia.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Días restantes vigencia";
            // 
            // txtPoliza
            // 
            this.txtPoliza.Location = new System.Drawing.Point(139, 59);
            this.txtPoliza.Name = "txtPoliza";
            this.txtPoliza.ReadOnly = true;
            this.txtPoliza.Size = new System.Drawing.Size(317, 20);
            this.txtPoliza.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Número póliza";
            // 
            // txtAseguradora
            // 
            this.txtAseguradora.Location = new System.Drawing.Point(139, 26);
            this.txtAseguradora.Name = "txtAseguradora";
            this.txtAseguradora.ReadOnly = true;
            this.txtAseguradora.Size = new System.Drawing.Size(134, 20);
            this.txtAseguradora.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Aseguradora";
            // 
            // groupBoxResumen
            // 
            this.groupBoxResumen.Controls.Add(this.txtValorAseguradora);
            this.groupBoxResumen.Controls.Add(this.label13);
            this.groupBoxResumen.Controls.Add(this.txtValorPaciente);
            this.groupBoxResumen.Controls.Add(this.label12);
            this.groupBoxResumen.Controls.Add(this.txtTotalServicios);
            this.groupBoxResumen.Controls.Add(this.label11);
            this.groupBoxResumen.Controls.Add(this.txtCopago);
            this.groupBoxResumen.Controls.Add(this.label2);
            this.groupBoxResumen.Location = new System.Drawing.Point(21, 293);
            this.groupBoxResumen.Name = "groupBoxResumen";
            this.groupBoxResumen.Size = new System.Drawing.Size(478, 122);
            this.groupBoxResumen.TabIndex = 6;
            this.groupBoxResumen.TabStop = false;
            this.groupBoxResumen.Text = "Resumen económico";
            // 
            // txtValorAseguradora
            // 
            this.txtValorAseguradora.Location = new System.Drawing.Point(348, 72);
            this.txtValorAseguradora.Name = "txtValorAseguradora";
            this.txtValorAseguradora.ReadOnly = true;
            this.txtValorAseguradora.Size = new System.Drawing.Size(108, 20);
            this.txtValorAseguradora.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(271, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Aseguradora";
            // 
            // txtValorPaciente
            // 
            this.txtValorPaciente.Location = new System.Drawing.Point(139, 72);
            this.txtValorPaciente.Name = "txtValorPaciente";
            this.txtValorPaciente.ReadOnly = true;
            this.txtValorPaciente.Size = new System.Drawing.Size(108, 20);
            this.txtValorPaciente.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Valor paciente";
            // 
            // txtTotalServicios
            // 
            this.txtTotalServicios.Location = new System.Drawing.Point(348, 31);
            this.txtTotalServicios.Name = "txtTotalServicios";
            this.txtTotalServicios.ReadOnly = true;
            this.txtTotalServicios.Size = new System.Drawing.Size(108, 20);
            this.txtTotalServicios.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(271, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Total servicios";
            // 
            // txtCopago
            // 
            this.txtCopago.Location = new System.Drawing.Point(139, 31);
            this.txtCopago.Name = "txtCopago";
            this.txtCopago.ReadOnly = true;
            this.txtCopago.Size = new System.Drawing.Size(108, 20);
            this.txtCopago.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Copago";
            // 
            // txtMedico
            // 
            this.txtMedico.Location = new System.Drawing.Point(531, 72);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.ReadOnly = true;
            this.txtMedico.Size = new System.Drawing.Size(260, 20);
            this.txtMedico.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(518, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Médico tratante";
            // 
            // lstDetalle
            // 
            this.lstDetalle.FormattingEnabled = true;
            this.lstDetalle.Location = new System.Drawing.Point(521, 161);
            this.lstDetalle.Name = "lstDetalle";
            this.lstDetalle.Size = new System.Drawing.Size(270, 212);
            this.lstDetalle.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(518, 141);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Detalle de servicios";
            // 
            // FacturacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 427);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lstDetalle);
            this.Controls.Add(this.txtMedico);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBoxResumen);
            this.Controls.Add(this.groupBoxSeguro);
            this.Controls.Add(this.groupBoxPaciente);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.chkRegistrar);
            this.Controls.Add(this.txtIdOrden);
            this.Controls.Add(this.label1);
            this.Name = "FacturacionForm";
            this.Text = "Generación de facturas";
            this.groupBoxPaciente.ResumeLayout(false);
            this.groupBoxPaciente.PerformLayout();
            this.groupBoxSeguro.ResumeLayout(false);
            this.groupBoxSeguro.PerformLayout();
            this.groupBoxResumen.ResumeLayout(false);
            this.groupBoxResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdOrden;
        private System.Windows.Forms.CheckBox chkRegistrar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox groupBoxPaciente;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxSeguro;
        private System.Windows.Forms.TextBox txtEstadoPoliza;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFechaFin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiasVigencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPoliza;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAseguradora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxResumen;
        private System.Windows.Forms.TextBox txtValorAseguradora;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtValorPaciente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalServicios;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCopago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMedico;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lstDetalle;
        private System.Windows.Forms.Label label15;
    }
}
