using System;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Infrastructure.Configuration;

namespace ClinicaIPS_U.UI {
    public partial class MenuPrincipal : Form {
        private readonly AppServiceProvider _services;
        private readonly Usuario _usuario;

        public MenuPrincipal(AppServiceProvider services, Usuario usuario) {
            InitializeComponent();
            _services = services;
            _usuario = usuario;
            ConfigurarPermisos();
        }

        private void ConfigurarPermisos() {
            pacientesToolStripMenuItem.Enabled = true;
            medicamentosToolStripMenuItem.Enabled = true;
            procedimientosToolStripMenuItem.Enabled = true;
            ayudasDiagnósticasToolStripMenuItem.Enabled = true;
            usuariosToolStripMenuItem.Enabled = true;
            facturaciónToolStripMenuItem.Enabled = true;
            ordenesToolStripMenuItem.Enabled = true;

            switch (_usuario.Rol) {
                case "Admin":
                    break;
                case "Médico":
                    usuariosToolStripMenuItem.Enabled = false;
                    facturaciónToolStripMenuItem.Enabled = false;
                    break;
                case "Enfermera":
                    usuariosToolStripMenuItem.Enabled = false;
                    facturaciónToolStripMenuItem.Enabled = false;
                    procedimientosToolStripMenuItem.Enabled = false;
                    ayudasDiagnósticasToolStripMenuItem.Enabled = false;
                    break;
                case "Soporte":
                    pacientesToolStripMenuItem.Enabled = false;
                    medicamentosToolStripMenuItem.Enabled = false;
                    procedimientosToolStripMenuItem.Enabled = false;
                    ayudasDiagnósticasToolStripMenuItem.Enabled = false;
                    facturaciónToolStripMenuItem.Enabled = false;
                    ordenesToolStripMenuItem.Enabled = false;
                    break;
                case "RRHH":
                    pacientesToolStripMenuItem.Enabled = false;
                    medicamentosToolStripMenuItem.Enabled = false;
                    procedimientosToolStripMenuItem.Enabled = false;
                    ayudasDiagnósticasToolStripMenuItem.Enabled = false;
                    ordenesToolStripMenuItem.Enabled = false;
                    facturaciónToolStripMenuItem.Enabled = false;
                    break;
                case "Administrativo":
                    usuariosToolStripMenuItem.Enabled = false;
                    medicamentosToolStripMenuItem.Enabled = false;
                    procedimientosToolStripMenuItem.Enabled = false;
                    ayudasDiagnósticasToolStripMenuItem.Enabled = false;
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
                    pacientesToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new PacienteForm(_services.Pacientes)) {
                frm.ShowDialog();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new UsuarioForm(_services.Usuarios)) {
                frm.ShowDialog();
            }
        }

        private void medicamentosToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new MedicamentoForm(_services.Medicamentos)) {
                frm.ShowDialog();
            }
        }

        private void procedimientosToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new ProcedimientoForm(_services.Procedimientos)) {
                frm.ShowDialog();
            }
        }

        private void ayudasDiagnósticasToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new AyudaDiagnosticaForm(_services.AyudasDiagnosticas)) {
                frm.ShowDialog();
            }
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new FacturacionForm(_services)) {
                frm.ShowDialog();
            }
        }

        private void ordenGeneralToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new OrdenForm(_services.Ordenes)) {
                frm.ShowDialog();
            }
        }

        private void ordenMedicamentosToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new OrdenMedicamentoForm(_services.Ordenes, _services.Medicamentos)) {
                frm.ShowDialog();
            }
        }

        private void ordenProcedimientosToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new OrdenProcedimientoForm(_services.Ordenes, _services.Procedimientos)) {
                frm.ShowDialog();
            }
        }

        private void ordenAyudasDiagnósticasToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var frm = new OrdenAyudaDiagnosticaForm(_services.Ordenes, _services.AyudasDiagnosticas)) {
                frm.ShowDialog();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
