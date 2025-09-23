using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClinicaIPS_U.Application.Services;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.ValueObjects;

namespace ClinicaIPS_U.UI {
    public partial class UsuarioForm: Form {

        private readonly UsuarioService _usuarioService;
        public UsuarioForm(UsuarioService usuarioService) {
            InitializeComponent();
            _usuarioService = usuarioService;
        }

        private void UsuarioForm_Load(object sender, EventArgs e) {
            cmbRol.Items.AddRange(new[] { "RRHH", "Médico", "Enfermera", "Administrativo", "Soporte" });
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                var nuevo = new Usuario {
                    Cedula = new DocumentoIdentidad(txtCedula.Text),
                    NombreCompleto = txtNombre.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = new Direccion(txtDireccion.Text),
                    Telefono = new Telefono(txtTelefono.Text),
                    Correo = new Email(txtCorreo.Text),
                    Rol = cmbRol.Text,
                    UsuarioLogin = txtUsuarioLogin.Text,
                    Contraseña = txtContraseña.Text
                };

                _usuarioService.Registrar(nuevo);
                MessageBox.Show("Usuario registrado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            var usuario = _usuarioService.BuscarPorCedula(txtCedula.Text);
            if (usuario != null) {
                txtNombre.Text = usuario.NombreCompleto;
                dtpFechaNacimiento.Value = usuario.FechaNacimiento;
                txtDireccion.Text = usuario.Direccion.ToString();
                txtTelefono.Text = usuario.Telefono.ToString();
                txtCorreo.Text = usuario.Correo.ToString();
                cmbRol.Text = usuario.Rol;
                txtUsuarioLogin.Text = usuario.UsuarioLogin;
                txtContraseña.Text = usuario.Contraseña;
            } else {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                var usuario = new Usuario {
                    Cedula = new DocumentoIdentidad(txtCedula.Text),
                    NombreCompleto = txtNombre.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = new Direccion(txtDireccion.Text),
                    Telefono = new Telefono(txtTelefono.Text),
                    Correo = new Email(txtCorreo.Text),
                    Rol = cmbRol.Text,
                    UsuarioLogin = txtUsuarioLogin.Text,
                    Contraseña = txtContraseña.Text
                };

                _usuarioService.Actualizar(usuario);
                MessageBox.Show("Usuario actualizado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                _usuarioService.Eliminar(txtCedula.Text);
                MessageBox.Show("Usuario eliminado correctamente");

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