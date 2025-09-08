using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaIPS_U.UI {
    public partial class MenuPrincipal : Form {

        private string rolUsuario;

        // Constructor vacío (por si lo usas en otros lados)
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        // Constructor que recibe el rol
        public MenuPrincipal(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            // 🔹 Todos tienen acceso a Pacientes
            pacientesToolStripMenuItem.Enabled = true;

            switch (rolUsuario)
            {
                case "Admin":
                    // Acceso completo
                    break;

                case "Médico":
                    usuariosToolStripMenuItem.Enabled = false;
                    facturaciónToolStripMenuItem.Enabled = false;
                    break;

                case "Enfermera":
                    usuariosToolStripMenuItem.Enabled = false;
                    facturaciónToolStripMenuItem.Enabled = false;
                    procedimientosToolStripMenuItem.Enabled = false;
                    break;

                case "Soporte":
                    // Solo acceso a Usuarios
                    pacientesToolStripMenuItem.Enabled = false;
                    medicamentosToolStripMenuItem.Enabled = false;
                    procedimientosToolStripMenuItem.Enabled = false;
                    ayudasDiagnósticasToolStripMenuItem.Enabled = false;
                    facturaciónToolStripMenuItem.Enabled = false;
                    ordenesToolStripMenuItem.Enabled = false;
                    break;

                default:
                    MessageBox.Show("Rol no reconocido, se asignarán permisos mínimos.");
                    usuariosToolStripMenuItem.Enabled = false;
                    medicamentosToolStripMenuItem.Enabled = false;
                    procedimientosToolStripMenuItem.Enabled = false;
                    ayudasDiagnósticasToolStripMenuItem.Enabled = false;
                    facturaciónToolStripMenuItem.Enabled = false;
                    ordenesToolStripMenuItem.Enabled = false;
                    break;
            }
        }


        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e) {
            PacienteForm frm = new PacienteForm();
            frm.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            UsuarioForm frm = new UsuarioForm();
            frm.ShowDialog();
        }

        private void medicamentosToolStripMenuItem_Click(object sender, EventArgs e) {
            MedicamentoForm frm = new MedicamentoForm();
            frm.ShowDialog();
        }

        private void procedimientosToolStripMenuItem_Click(object sender, EventArgs e) {
            ProcedimientoForm frm = new ProcedimientoForm();
            frm.ShowDialog();
        }

        private void ayudasDiagnósticasToolStripMenuItem_Click(object sender, EventArgs e) {
            AyudaDiagnosticaForm frm = new AyudaDiagnosticaForm();
            frm.ShowDialog();
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e) {
            FacturacionForm frm = new FacturacionForm();
            frm.ShowDialog();
        }

        private void ordenGeneralToolStripMenuItem_Click(object sender, EventArgs e) {
            OrdenForm frm = new OrdenForm();
            frm.ShowDialog();
        }

        private void ordenMedicamentosToolStripMenuItem_Click(object sender, EventArgs e) {
            OrdenMedicamentoForm frm = new OrdenMedicamentoForm();
            frm.ShowDialog();
        }

        private void ordenProcedimientosToolStripMenuItem_Click(object sender, EventArgs e) {
            OrdenProcedimientoForm frm = new OrdenProcedimientoForm();
            frm.ShowDialog();
        }

        private void ordenAyudasDiagnósticasToolStripMenuItem_Click(object sender, EventArgs e) {
            OrdenAyudaDiagnosticaForm frm = new OrdenAyudaDiagnosticaForm();
            frm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}