namespace ClinicaIPS_U.UI
{
    partial class PacienteForm
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
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxCredenciales = new System.Windows.Forms.GroupBox();
            this.txtContrasenaPortal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUsuarioPortal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxContacto = new System.Windows.Forms.GroupBox();
            this.txtContactoTelefono = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtContactoRelacion = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContactoApellidos = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContactoNombres = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxSeguro = new System.Windows.Forms.GroupBox();
            this.dtpSeguroVigencia = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.chkSeguroActivo = new System.Windows.Forms.CheckBox();
            this.txtSeguroPoliza = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSeguroCompania = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBoxDatos.SuspendLayout();
            this.groupBoxCredenciales.SuspendLayout();
            this.groupBoxContacto.SuspendLayout();
            this.groupBoxSeguro.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.txtCorreo);
            this.groupBoxDatos.Controls.Add(this.txtTelefono);
            this.groupBoxDatos.Controls.Add(this.txtDireccion);
            this.groupBoxDatos.Controls.Add(this.cmbGenero);
            this.groupBoxDatos.Controls.Add(this.dtpFechaNacimiento);
            this.groupBoxDatos.Controls.Add(this.txtNombre);
            this.groupBoxDatos.Controls.Add(this.txtCedula);
            this.groupBoxDatos.Controls.Add(this.label7);
            this.groupBoxDatos.Controls.Add(this.label6);
            this.groupBoxDatos.Controls.Add(this.label5);
            this.groupBoxDatos.Controls.Add(this.label4);
            this.groupBoxDatos.Controls.Add(this.label3);
            this.groupBoxDatos.Controls.Add(this.label2);
            this.groupBoxDatos.Controls.Add(this.label1);
            this.groupBoxDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxDatos.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Size = new System.Drawing.Size(400, 250);
            this.groupBoxDatos.TabIndex = 0;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Datos del paciente";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCorreo.Location = new System.Drawing.Point(145, 205);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(229, 22);
            this.txtCorreo.TabIndex = 6;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtTelefono.Location = new System.Drawing.Point(145, 177);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(229, 22);
            this.txtTelefono.TabIndex = 5;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDireccion.Location = new System.Drawing.Point(145, 149);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(229, 22);
            this.txtDireccion.TabIndex = 4;
            // 
            // cmbGenero
            // 
            this.cmbGenero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(145, 121);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(229, 24);
            this.cmbGenero.TabIndex = 3;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(145, 93);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(229, 22);
            this.dtpFechaNacimiento.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNombre.Location = new System.Drawing.Point(145, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(229, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCedula.Location = new System.Drawing.Point(145, 37);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(229, 22);
            this.txtCedula.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Correo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Teléfono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Género";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha nacimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cédula";
            // 
            // groupBoxCredenciales
            // 
            this.groupBoxCredenciales.Controls.Add(this.txtContrasenaPortal);
            this.groupBoxCredenciales.Controls.Add(this.label9);
            this.groupBoxCredenciales.Controls.Add(this.txtUsuarioPortal);
            this.groupBoxCredenciales.Controls.Add(this.label8);
            this.groupBoxCredenciales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxCredenciales.Location = new System.Drawing.Point(430, 12);
            this.groupBoxCredenciales.Name = "groupBoxCredenciales";
            this.groupBoxCredenciales.Size = new System.Drawing.Size(318, 120);
            this.groupBoxCredenciales.TabIndex = 1;
            this.groupBoxCredenciales.TabStop = false;
            this.groupBoxCredenciales.Text = "Credenciales del portal";
            // 
            // txtContrasenaPortal
            // 
            this.txtContrasenaPortal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtContrasenaPortal.Location = new System.Drawing.Point(136, 71);
            this.txtContrasenaPortal.Name = "txtContrasenaPortal";
            this.txtContrasenaPortal.Size = new System.Drawing.Size(168, 22);
            this.txtContrasenaPortal.TabIndex = 1;
            this.txtContrasenaPortal.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Contraseña";
            // 
            // txtUsuarioPortal
            // 
            this.txtUsuarioPortal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtUsuarioPortal.Location = new System.Drawing.Point(136, 34);
            this.txtUsuarioPortal.Name = "txtUsuarioPortal";
            this.txtUsuarioPortal.Size = new System.Drawing.Size(168, 22);
            this.txtUsuarioPortal.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Usuario";
            // 
            // groupBoxContacto
            // 
            this.groupBoxContacto.Controls.Add(this.txtContactoTelefono);
            this.groupBoxContacto.Controls.Add(this.label13);
            this.groupBoxContacto.Controls.Add(this.txtContactoRelacion);
            this.groupBoxContacto.Controls.Add(this.label12);
            this.groupBoxContacto.Controls.Add(this.txtContactoApellidos);
            this.groupBoxContacto.Controls.Add(this.label11);
            this.groupBoxContacto.Controls.Add(this.txtContactoNombres);
            this.groupBoxContacto.Controls.Add(this.label10);
            this.groupBoxContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxContacto.Location = new System.Drawing.Point(430, 138);
            this.groupBoxContacto.Name = "groupBoxContacto";
            this.groupBoxContacto.Size = new System.Drawing.Size(318, 173);
            this.groupBoxContacto.TabIndex = 2;
            this.groupBoxContacto.TabStop = false;
            this.groupBoxContacto.Text = "Contacto de emergencia";
            // 
            // txtContactoTelefono
            // 
            this.txtContactoTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtContactoTelefono.Location = new System.Drawing.Point(136, 131);
            this.txtContactoTelefono.Name = "txtContactoTelefono";
            this.txtContactoTelefono.Size = new System.Drawing.Size(168, 22);
            this.txtContactoTelefono.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Teléfono";
            // 
            // txtContactoRelacion
            // 
            this.txtContactoRelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtContactoRelacion.Location = new System.Drawing.Point(136, 99);
            this.txtContactoRelacion.Name = "txtContactoRelacion";
            this.txtContactoRelacion.Size = new System.Drawing.Size(168, 22);
            this.txtContactoRelacion.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Relación";
            // 
            // txtContactoApellidos
            // 
            this.txtContactoApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtContactoApellidos.Location = new System.Drawing.Point(136, 65);
            this.txtContactoApellidos.Name = "txtContactoApellidos";
            this.txtContactoApellidos.Size = new System.Drawing.Size(168, 22);
            this.txtContactoApellidos.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Apellidos";
            // 
            // txtContactoNombres
            // 
            this.txtContactoNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtContactoNombres.Location = new System.Drawing.Point(136, 31);
            this.txtContactoNombres.Name = "txtContactoNombres";
            this.txtContactoNombres.Size = new System.Drawing.Size(168, 22);
            this.txtContactoNombres.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Nombres";
            // 
            // groupBoxSeguro
            // 
            this.groupBoxSeguro.Controls.Add(this.dtpSeguroVigencia);
            this.groupBoxSeguro.Controls.Add(this.label16);
            this.groupBoxSeguro.Controls.Add(this.chkSeguroActivo);
            this.groupBoxSeguro.Controls.Add(this.txtSeguroPoliza);
            this.groupBoxSeguro.Controls.Add(this.label15);
            this.groupBoxSeguro.Controls.Add(this.txtSeguroCompania);
            this.groupBoxSeguro.Controls.Add(this.label14);
            this.groupBoxSeguro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBoxSeguro.Location = new System.Drawing.Point(12, 268);
            this.groupBoxSeguro.Name = "groupBoxSeguro";
            this.groupBoxSeguro.Size = new System.Drawing.Size(736, 130);
            this.groupBoxSeguro.TabIndex = 3;
            this.groupBoxSeguro.TabStop = false;
            this.groupBoxSeguro.Text = "Seguro médico";
            // 
            // dtpSeguroVigencia
            // 
            this.dtpSeguroVigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtpSeguroVigencia.Location = new System.Drawing.Point(516, 55);
            this.dtpSeguroVigencia.Name = "dtpSeguroVigencia";
            this.dtpSeguroVigencia.Size = new System.Drawing.Size(201, 22);
            this.dtpSeguroVigencia.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(402, 58);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 16);
            this.label16.TabIndex = 5;
            this.label16.Text = "Vigencia hasta";
            // 
            // chkSeguroActivo
            // 
            this.chkSeguroActivo.AutoSize = true;
            this.chkSeguroActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkSeguroActivo.Location = new System.Drawing.Point(405, 31);
            this.chkSeguroActivo.Name = "chkSeguroActivo";
            this.chkSeguroActivo.Size = new System.Drawing.Size(68, 20);
            this.chkSeguroActivo.TabIndex = 2;
            this.chkSeguroActivo.Text = "Activo";
            this.chkSeguroActivo.UseVisualStyleBackColor = true;
            // 
            // txtSeguroPoliza
            // 
            this.txtSeguroPoliza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSeguroPoliza.Location = new System.Drawing.Point(169, 86);
            this.txtSeguroPoliza.Name = "txtSeguroPoliza";
            this.txtSeguroPoliza.Size = new System.Drawing.Size(205, 22);
            this.txtSeguroPoliza.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 16);
            this.label15.TabIndex = 2;
            this.label15.Text = "Número póliza";
            // 
            // txtSeguroCompania
            // 
            this.txtSeguroCompania.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSeguroCompania.Location = new System.Drawing.Point(169, 33);
            this.txtSeguroCompania.Name = "txtSeguroCompania";
            this.txtSeguroCompania.Size = new System.Drawing.Size(205, 22);
            this.txtSeguroCompania.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Compañía de seguro";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(198, 415);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 30);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(294, 415);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(390, 415);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 30);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(102, 415);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 30);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // PacienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 463);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBoxSeguro);
            this.Controls.Add(this.groupBoxContacto);
            this.Controls.Add(this.groupBoxCredenciales);
            this.Controls.Add(this.groupBoxDatos);
            this.Name = "PacienteForm";
            this.Text = "Gestión de pacientes";
            this.Load += new System.EventHandler(this.PacienteForm_Load);
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.groupBoxCredenciales.ResumeLayout(false);
            this.groupBoxCredenciales.PerformLayout();
            this.groupBoxContacto.ResumeLayout(false);
            this.groupBoxContacto.PerformLayout();
            this.groupBoxSeguro.ResumeLayout(false);
            this.groupBoxSeguro.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxCredenciales;
        private System.Windows.Forms.TextBox txtContrasenaPortal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUsuarioPortal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxContacto;
        private System.Windows.Forms.TextBox txtContactoTelefono;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtContactoRelacion;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtContactoApellidos;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtContactoNombres;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBoxSeguro;
        private System.Windows.Forms.DateTimePicker dtpSeguroVigencia;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkSeguroActivo;
        private System.Windows.Forms.TextBox txtSeguroPoliza;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSeguroCompania;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBuscar;
    }
}
