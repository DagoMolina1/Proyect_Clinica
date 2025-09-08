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
    public partial class MedicamentoForm: Form {

        private MedicamentoBL medicamentoBL = new MedicamentoBL();
        public MedicamentoForm() {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtNombre.Text)) {
                    MessageBox.Show("El nombre del medicamento es obligatorio");
                    return;
                }

                if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo <= 0) {
                    MessageBox.Show("El costo debe ser un número mayor que 0");
                    return;
                }

                Medicamento nuevo = new Medicamento {
                    Nombre = txtNombre.Text,
                    Dosis = txtDosis.Text,
                    Costo = costo
                };

                medicamentoBL.RegistrarMedicamento(nuevo);
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

            var medicamentos = medicamentoBL.ObtenerMedicamentos();
            var medicamento = medicamentos.FirstOrDefault(m => m.IdMedicamento == id);

            if (medicamento != null) {
                txtNombre.Text = medicamento.Nombre;
                txtDosis.Text = medicamento.Dosis;
                txtCosto.Text = medicamento.Costo.ToString();
            } else {
                MessageBox.Show("❌ Medicamento no encontrado");
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

                Medicamento medicamento = new Medicamento {
                    IdMedicamento = id,
                    Nombre = txtNombre.Text,
                    Dosis = txtDosis.Text,
                    Costo = costo
                };

                medicamentoBL.ActualizarMedicamento(medicamento);
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

                medicamentoBL.EliminarMedicamento(id);
                MessageBox.Show("Medicamento eliminado correctamente");

                // Limpiar campos
                txtNombre.Clear();
                txtDosis.Clear();
                txtCosto.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}