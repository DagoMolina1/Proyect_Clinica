using System;
using System.Linq;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Services;

namespace ClinicaIPS_U.UI {
    public partial class MedicamentoForm : Form {
        private readonly MedicamentoService _medicamentoService;

        public MedicamentoForm(MedicamentoService medicamentoService) {
            InitializeComponent();
            _medicamentoService = medicamentoService;
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)) {
                    MessageBox.Show("El nombre del medicamento es obligatorio");
                    return;
                }

                if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo <= 0) {
                    MessageBox.Show("El costo debe ser un número mayor que 0");
                    return;
                }

                var nuevo = new Medicamento {
                    Nombre = txtNombre.Text,
                    Dosis = txtDosis.Text,
                    Costo = costo
                };

                _medicamentoService.Registrar(nuevo);
                MessageBox.Show("Medicamento registrado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (!int.TryParse(txtIdMedicamento.Text, out int id)) {
                MessageBox.Show("Ingrese un ID de medicamento válido");
                return;
            }

            var medicamento = _medicamentoService.BuscarPorId(id);

            if (medicamento != null) {
                txtNombre.Text = medicamento.Nombre;
                txtDosis.Text = medicamento.Dosis;
                txtCosto.Text = medicamento.Costo.ToString();
            } else {
                MessageBox.Show("Medicamento no encontrado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdMedicamento.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para modificar");
                    return;
                }

                if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo <= 0) {
                    MessageBox.Show("El costo debe ser un número mayor que 0");
                    return;
                }

                var medicamento = new Medicamento {
                    IdMedicamento = id,
                    Nombre = txtNombre.Text,
                    Dosis = txtDosis.Text,
                    Costo = costo
                };

                _medicamentoService.Actualizar(medicamento);
                MessageBox.Show("Medicamento actualizado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdMedicamento.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para eliminar");
                    return;
                }

                _medicamentoService.Eliminar(id);
                MessageBox.Show("Medicamento eliminado correctamente");
                txtNombre.Clear();
                txtDosis.Clear();
                txtCosto.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
