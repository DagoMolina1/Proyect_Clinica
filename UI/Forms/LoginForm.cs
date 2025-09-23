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

namespace ClinicaIPS_U.UI {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e) {
            LoginBL loginBL = new LoginBL();
            string rol = loginBL.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);

            if (rol != null)
            {
                MessageBox.Show($"Bienvenido, rol: {rol}");

                // Pasamos el rol al menú
                MenuPrincipal menu = new MenuPrincipal(rol);
                this.Hide();
                menu.ShowDialog();
                this.Close();
            } else {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}