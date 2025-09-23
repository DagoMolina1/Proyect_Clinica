using System;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Services;
using ClinicaIPS_U.Domain.ValueObjects;

namespace ClinicaIPS_U.UI {
    public partial class PacienteForm : Form {
        private readonly PacienteService _pacienteService;

        public PacienteForm(PacienteService pacienteService) {
            InitializeComponent();
            _pacienteService = pacienteService;
        }

        private void PacienteForm_Load(object sender, EventArgs e) {
            cmbGenero.Items.AddRange(new[] { "Masculino", "Femenino", "Otro" });
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                var nuevo = ConstruirPacienteDesdeFormulario();
                _pacienteService.Registrar(nuevo);
                MessageBox.Show("Paciente guardado con éxito");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            try {
                var paciente = _pacienteService.BuscarPorCedula(txtCedula.Text);

                if (paciente != null) {
                    CargarPacienteEnFormulario(paciente);
                } else {
                    MessageBox.Show("Paciente no encontrado");
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                var paciente = ConstruirPacienteDesdeFormulario();
                _pacienteService.Actualizar(paciente);
                MessageBox.Show("Paciente actualizado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                _pacienteService.Eliminar(txtCedula.Text);
                MessageBox.Show("Paciente eliminado correctamente");
                LimpiarFormulario();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private Paciente ConstruirPacienteDesdeFormulario() {
            var paciente = new Paciente {
                Cedula = new DocumentoIdentidad(txtCedula.Text),
                NombreCompleto = txtNombre.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Genero = cmbGenero.Text,
                Direccion = new Direccion(txtDireccion.Text),
                Telefono = new Telefono(txtTelefono.Text),
                Correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : new Email(txtCorreo.Text),
                UsuarioPortal = txtUsuarioPortal.Text,
                ContrasenaPortal = txtContrasenaPortal.Text,
                ContactoEmergencia = new ContactoEmergencia {
                    Nombres = txtContactoNombres.Text,
                    Apellidos = txtContactoApellidos.Text,
                    Relacion = txtContactoRelacion.Text,
                    TelefonoEmergencia = new Telefono(txtContactoTelefono.Text)
                }
            };

            if (!string.IsNullOrWhiteSpace(txtSeguroCompania.Text) && !string.IsNullOrWhiteSpace(txtSeguroPoliza.Text)) {
                paciente.SeguroMedico = new SeguroMedico {
                    NombreCompania = txtSeguroCompania.Text,
                    NumeroPoliza = txtSeguroPoliza.Text,
                    Estado = chkSeguroActivo.Checked,
                    Vigencia = dtpSeguroVigencia.Value
                };
            }

            return paciente;
        }

        private void CargarPacienteEnFormulario(Paciente paciente) {
            txtCedula.Text = paciente.Cedula.Value;
            txtNombre.Text = paciente.NombreCompleto;
            dtpFechaNacimiento.Value = paciente.FechaNacimiento;
            cmbGenero.Text = paciente.Genero;
            txtDireccion.Text = paciente.Direccion.ToString();
            txtTelefono.Text = paciente.Telefono.ToString();
            txtCorreo.Text = paciente.Correo?.ToString() ?? string.Empty;
            txtUsuarioPortal.Text = paciente.UsuarioPortal;
            txtContrasenaPortal.Text = paciente.ContrasenaPortal;

            if (paciente.ContactoEmergencia != null) {
                txtContactoNombres.Text = paciente.ContactoEmergencia.Nombres;
                txtContactoApellidos.Text = paciente.ContactoEmergencia.Apellidos;
                txtContactoRelacion.Text = paciente.ContactoEmergencia.Relacion;
                txtContactoTelefono.Text = paciente.ContactoEmergencia.TelefonoEmergencia.ToString();
            }

            if (paciente.SeguroMedico != null) {
                txtSeguroCompania.Text = paciente.SeguroMedico.NombreCompania;
                txtSeguroPoliza.Text = paciente.SeguroMedico.NumeroPoliza;
                chkSeguroActivo.Checked = paciente.SeguroMedico.Estado;
                dtpSeguroVigencia.Value = paciente.SeguroMedico.Vigencia;
            } else {
                txtSeguroCompania.Clear();
                txtSeguroPoliza.Clear();
                chkSeguroActivo.Checked = false;
                dtpSeguroVigencia.Value = DateTime.Today;
            }
        }

        private void LimpiarFormulario() {
            txtCedula.Clear();
            txtNombre.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            cmbGenero.SelectedIndex = -1;
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtUsuarioPortal.Clear();
            txtContrasenaPortal.Clear();
            txtContactoNombres.Clear();
            txtContactoApellidos.Clear();
            txtContactoRelacion.Clear();
            txtContactoTelefono.Clear();
            txtSeguroCompania.Clear();
            txtSeguroPoliza.Clear();
            chkSeguroActivo.Checked = false;
            dtpSeguroVigencia.Value = DateTime.Today;
        }
    }
}
