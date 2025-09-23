using System;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Infrastructure.Configuration;

namespace ClinicaIPS_U.UI {
    public partial class LoginForm : Form {
        private readonly AppServiceProvider _services;

        public LoginForm(AppServiceProvider services) {
            InitializeComponent();
            _services = services;
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e) {
            Usuario usuario = _services.Usuarios.Login(txtUsuario.Text, txtContraseña.Text);

            if (usuario != null) {
                MessageBox.Show($"Bienvenido, rol: {usuario.Rol}");

                using (var menu = new MenuPrincipal(_services, usuario)) {
                    Hide();
                    menu.ShowDialog();
                    Show();
                }
            } else {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
