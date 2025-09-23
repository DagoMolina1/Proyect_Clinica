namespace ClinicaIPS_U.UI
{
    partial class OrdenProcedimientoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdEspecialidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkRequiereEspecialista = new System.Windows.Forms.CheckBox();
            this.txtFrecuencia = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVeces = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombreProcedimiento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdProcedimiento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdOrden = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdOrdenProcedimiento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCostoUnitario);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtIdEspecialidad);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkRequiereEspecialista);
            this.groupBox1.Controls.Add(this.txtFrecuencia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtVeces);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNombreProcedimiento);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIdProcedimiento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNumeroItem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIdOrden);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIdOrdenProcedimiento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la orden";
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCostoUnitario.Location = new System.Drawing.Point(429, 199);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.Size = new System.Drawing.Size(145, 22);
            this.txtCostoUnitario.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Costo unitario";
            // 
            // txtIdEspecialidad
            // 
            this.txtIdEspecialidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtIdEspecialidad.Location = new System.Drawing.Point(157, 199);
            this.txtIdEspecialidad.Name = "txtIdEspecialidad";
            this.txtIdEspecialidad.Size = new System.Drawing.Size(134, 22);
            this.txtIdEspecialidad.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Id especialidad";
            // 
            // chkRequiereEspecialista
            // 
            this.chkRequiereEspecialista.AutoSize = true;
            this.chkRequiereEspecialista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkRequiereEspecialista.Location = new System.Drawing.Point(302, 164);
            this.chkRequiereEspecialista.Name = "chkRequiereEspecialista";
            this.chkRequiereEspecialista.Size = new System.Drawing.Size(172, 20);
            this.chkRequiereEspecialista.TabIndex = 6;
            this.chkRequiereEspecialista.Text = "Requiere especialista";
            this.chkRequiereEspecialista.UseVisualStyleBackColor = true;
            // 
            // txtFrecuencia
            // 
            this.txtFrecuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtFrecuencia.Location = new System.Drawing.Point(157, 162);
            this.txtFrecuencia.Name = "txtFrecuencia";
            this.txtFrecuencia.Size = new System.Drawing.Size(134, 22);
            this.txtFrecuencia.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Frecuencia";
            // 
            // txtVeces
            // 
            this.txtVeces.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtVeces.Location = new System.Drawing.Point(429, 126);
            this.txtVeces.Name = "txtVeces";
            this.txtVeces.Size = new System.Drawing.Size(145, 22);
            this.txtVeces.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Número de veces";
            // 
            // txtNombreProcedimiento
            // 
            this.txtNombreProcedimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNombreProcedimiento.Location = new System.Drawing.Point(157, 126);
            this.txtNombreProcedimiento.Name = "txtNombreProcedimiento";
            this.txtNombreProcedimiento.Size = new System.Drawing.Size(134, 22);
            this.txtNombreProcedimiento.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre procedimiento";
            // 
            // txtIdProcedimiento
            // 
            this.txtIdProcedimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtIdProcedimiento.Location = new System.Drawing.Point(429, 90);
            this.txtIdProcedimiento.Name = "txtIdProcedimiento";
            this.txtIdProcedimiento.Size = new System.Drawing.Size(145, 22);
            this.txtIdProcedimiento.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Id procedimiento";
            // 
            // txtNumeroItem
            // 
            this.txtNumeroItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNumeroItem.Location = new System.Drawing.Point(157, 90);
            this.txtNumeroItem.Name = "txtNumeroItem";
            this.txtNumeroItem.Size = new System.Drawing.Size(134, 22);
            this.txtNumeroItem.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Número ítem";
            // 
            // txtIdOrden
            // 
            this.txtIdOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtIdOrden.Location = new System.Drawing.Point(429, 54);
            this.txtIdOrden.Name = "txtIdOrden";
            this.txtIdOrden.Size = new System.Drawing.Size(145, 22);
            this.txtIdOrden.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id orden";
            // 
            // txtIdOrdenProcedimiento
            // 
            this.txtIdOrdenProcedimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtIdOrdenProcedimiento.Location = new System.Drawing.Point(219, 26);
            this.txtIdOrdenProcedimiento.Name = "txtIdOrdenProcedimiento";
            this.txtIdOrdenProcedimiento.Size = new System.Drawing.Size(355, 22);
            this.txtIdOrdenProcedimiento.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id orden procedimiento";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(211, 271);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(497, 271);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(401, 271);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 30);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(305, 271);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 30);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // OrdenProcedimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 314);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "OrdenProcedimientoForm";
            this.Text = "Orden de procedimientos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdEspecialidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkRequiereEspecialista;
        private System.Windows.Forms.TextBox txtFrecuencia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVeces;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombreProcedimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdProcedimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdOrden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdOrdenProcedimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBuscar;
    }
}
