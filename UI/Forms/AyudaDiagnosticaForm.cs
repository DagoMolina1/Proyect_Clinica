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

namespace ClinicaIPS_U.UI {
    public partial class AyudaDiagnosticaForm : Form {

        private AyudaDiagnosticaBL ayudaBL = new AyudaDiagnosticaBL();

        public AyudaDiagnosticaForm() {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtNombre.Text)) {
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

                ayudaBL.RegistrarAyuda(nueva);
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

            var ayudas = ayudaBL.ObtenerAyudas();
            var ayuda = ayudas.FirstOrDefault(a => a.IdAyuda == id);

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

                ayudaBL.ActualizarAyuda(ayuda);
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

                ayudaBL.EliminarAyuda(id);
                MessageBox.Show("Ayuda diagnóstica eliminada correctamente");

                // Limpiar campos
                txtNombre.Clear();
                txtCosto.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}