using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClinicaIPS_U.Domain.Services;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.ValueObjects;

namespace ClinicaIPS_U.UI {
    public partial class PacienteForm: Form {
        private readonly PacienteService _pacienteService;

        public PacienteForm(PacienteService pacienteService) {
            InitializeComponent();
            _pacienteService = pacienteService;
        }

        private void PacienteForm_Load(object sender, EventArgs e) {
            // Cargar opciones del ComboBox Género
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbGenero.Items.Add("Otro");
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                var nuevo = new Paciente {
                    Cedula = new DocumentoIdentidad(txtCedula.Text),
                    NombreCompleto = txtNombre.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Genero = cmbGenero.Text,
                    Direccion = new Direccion(txtDireccion.Text),
                    Telefono = new Telefono(txtTelefono.Text),
                    Correo = new Email(txtCorreo.Text)
                };

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
                    txtNombre.Text = paciente.NombreCompleto;
                    dtpFechaNacimiento.Value = paciente.FechaNacimiento;
                    cmbGenero.Text = paciente.Genero;
                    txtDireccion.Text = paciente.Direccion.ToString();
                    txtTelefono.Text = paciente.Telefono.ToString();
                    txtCorreo.Text = paciente.Correo.ToString();
                } else {
                    MessageBox.Show("Paciente no encontrado");
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                var paciente = new Paciente {
                    Cedula = new DocumentoIdentidad(txtCedula.Text),
                    NombreCompleto = txtNombre.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Genero = cmbGenero.Text,
                    Direccion = new Direccion(txtDireccion.Text),
                    Telefono = new Telefono(txtTelefono.Text),
                    Correo = new Email(txtCorreo.Text)
                };

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

                txtCedula.Clear();
                txtNombre.Clear();
                txtDireccion.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                cmbGenero.SelectedIndex = -1;
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}