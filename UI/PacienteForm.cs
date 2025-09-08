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
    public partial class PacienteForm: Form {
        private PacienteBL pacienteBL = new PacienteBL();

        public PacienteForm() {
            InitializeComponent();
        }

        private void PacienteForm_Load(object sender, EventArgs e) {
            // Cargar opciones del ComboBox Género
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbGenero.Items.Add("Otro");
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                // Validaciones de los campos
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

                if (!Validador.EsFechaNacimientoValida(dtpFechaNacimiento.Value)) {
                    MessageBox.Show("La fecha de nacimiento no es válida");
                    return;
                }

                // Crear el objeto Paciente
                Paciente nuevo = new Paciente {
                    Cedula = txtCedula.Text,
                    NombreCompleto = txtNombre.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Genero = cmbGenero.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text
                };

                // Guardar en la BD
                pacienteBL.RegistrarPaciente(nuevo);

                MessageBox.Show("Paciente guardado con éxito");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            // Aquí lo ideal es buscar por cédula
            string cedula = txtCedula.Text;

            var pacientes = pacienteBL.ObtenerPacientes(); // traer lista
            var paciente = pacientes.FirstOrDefault(p => p.Cedula == cedula);

            if (paciente != null) {
                txtNombre.Text = paciente.NombreCompleto;
                dtpFechaNacimiento.Value = paciente.FechaNacimiento;
                cmbGenero.Text = paciente.Genero;
                txtDireccion.Text = paciente.Direccion;
                txtTelefono.Text = paciente.Telefono;
                txtCorreo.Text = paciente.Correo;
            } else {
                MessageBox.Show("Paciente no encontrado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                Paciente paciente = new Paciente {
                    Cedula = txtCedula.Text,
                    NombreCompleto = txtNombre.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Genero = cmbGenero.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text
                };

                pacienteBL.ActualizarPaciente(paciente);
                MessageBox.Show("Paciente actualizado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                string cedula = txtCedula.Text;

                if (string.IsNullOrEmpty(cedula)) {
                    MessageBox.Show("Ingrese la cédula del paciente a eliminar");
                    return;
                }

                pacienteBL.EliminarPaciente(cedula);
                MessageBox.Show("❌ Paciente eliminado correctamente");

                // Limpieza de campos
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
