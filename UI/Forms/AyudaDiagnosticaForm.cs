using System;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Services;

namespace ClinicaIPS_U.UI {
    public partial class AyudaDiagnosticaForm : Form {
        private readonly AyudaDiagnosticaService _ayudaService;

        public AyudaDiagnosticaForm(AyudaDiagnosticaService ayudaService) {
            InitializeComponent();
            _ayudaService = ayudaService;
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)) {
                    MessageBox.Show("El nombre es obligatorio");
                    return;
                }

                if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo <= 0) {
                    MessageBox.Show("El costo debe ser un número mayor que 0");
                    return;
                }

                AyudaDiagnostica nueva = new AyudaDiagnostica {
                    Nombre = txtNombre.Text,
                    Costo = costo
                };

                _ayudaService.Registrar(nueva);
                MessageBox.Show("Ayuda diagnóstica registrada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (!int.TryParse(txtIdAyuda.Text, out int id)) {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var ayuda = _ayudaService.BuscarPorId(id);

            if (ayuda != null) {
                txtNombre.Text = ayuda.Nombre;
                txtCosto.Text = ayuda.Costo.ToString();
            } else {
                MessageBox.Show("Ayuda diagnóstica no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdAyuda.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para modificar");
                    return;
                }

                if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo <= 0) {
                    MessageBox.Show("El costo debe ser mayor a 0");
                    return;
                }

                AyudaDiagnostica ayuda = new AyudaDiagnostica {
                    IdAyuda = id,
                    Nombre = txtNombre.Text,
                    Costo = costo
                };

                _ayudaService.Actualizar(ayuda);
                MessageBox.Show("Ayuda diagnóstica actualizada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdAyuda.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para eliminar");
                    return;
                }

                _ayudaService.Eliminar(id);
                MessageBox.Show("Ayuda diagnóstica eliminada correctamente");
                txtNombre.Clear();
                txtCosto.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
