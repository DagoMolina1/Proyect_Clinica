using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClinicaIPS_U.Business;
using ClinicaIPS_U.Entities;
using ClinicaIPS_U.Validations;

namespace ClinicaIPS_U.UI {
    public partial class UsuarioForm: Form {

        private UsuarioBL usuarioBL = new UsuarioBL();
        public UsuarioForm() {
            InitializeComponent();
        }

        private void UsuarioForm_Load(object sender, EventArgs e) {
            // Cargar roles disponibles en el ComboBox
            cmbRol.Items.Add("RRHH");
            cmbRol.Items.Add("Médico");
            cmbRol.Items.Add("Enfermera");
            cmbRol.Items.Add("Administrativo");
            cmbRol.Items.Add("Soporte");
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (!Validador.EsCedulaValida(txtCedula.Text)) {
                    MessageBox.Show("La cédula no es válida");
                    return;
                }

                if (!Validador.EsCorreoValido(txtCorreo.Text)) {
                    MessageBox.Show("El correo no es válido");
                    return;
                }

                if (!Validador.EsTelefonoValido(txtTelefono.Text)) {
                    MessageBox.Show("El teléfono debe tener 10 dígitos numéricos");
                    return;
                }

                if (!Validador.EsContraseñaValida(txtContraseña.Text)) {
                    MessageBox.Show("La contraseña no cumple con los requisitos");
                    return;
                }

                Usuario nuevo = new Usuario {
                    Cedula = txtCedula.Text,
                    NombreCompleto = txtNombre.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    Rol = cmbRol.Text,
                    UsuarioLogin = txtUsuarioLogin.Text,
                    Contraseña = txtContraseña.Text
                };

                usuarioBL.RegistrarUsuario(nuevo);
                MessageBox.Show("Usuario registrado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            string cedula = txtCedula.Text;

            var usuarios = usuarioBL.ObtenerUsuarios();
            var usuario = usuarios.FirstOrDefault(u => u.Cedula == cedula);

            if (usuario != null) {
                txtNombre.Text = usuario.NombreCompleto;
                dtpFechaNacimiento.Value = usuario.FechaNacimiento;
                txtDireccion.Text = usuario.Direccion;
                txtTelefono.Text = usuario.Telefono;
                txtCorreo.Text = usuario.Correo;
                cmbRol.Text = usuario.Rol;
                txtUsuarioLogin.Text = usuario.UsuarioLogin;
                txtContraseña.Text = usuario.Contraseña;
            } else {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                Usuario usuario = new Usuario {
                    Cedula = txtCedula.Text,
                    NombreCompleto = txtNombre.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    Rol = cmbRol.Text,
                    UsuarioLogin = txtUsuarioLogin.Text,
                    Contraseña = txtContraseña.Text
                };

                usuarioBL.ActualizarUsuario(usuario);
                MessageBox.Show("Usuario actualizado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                string cedula = txtCedula.Text;

                if (string.IsNullOrEmpty(cedula)) {
                    MessageBox.Show("Ingrese la cédula del usuario a eliminar");
                    return;
                }

                usuarioBL.EliminarUsuario(cedula);
                MessageBox.Show("Usuario eliminado correctamente");

                // Limpiar campos
                txtNombre.Clear();
                txtDireccion.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                cmbRol.SelectedIndex = -1;
                txtUsuarioLogin.Clear();
                txtContraseña.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
