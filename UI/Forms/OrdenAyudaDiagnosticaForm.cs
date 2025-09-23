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
    public partial class OrdenAyudaDiagnosticaForm : Form {

        private OrdenAyudaDiagnosticaBL ordenAyudaBL = new OrdenAyudaDiagnosticaBL();

        public OrdenAyudaDiagnosticaForm() {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrden.Text, out int idOrden) ||
                    !int.TryParse(txtIdAyuda.Text, out int idAyuda) ||
                    !int.TryParse(txtCantidad.Text, out int cantidad)) {
                    MessageBox.Show("Debe ingresar valores numéricos válidos para IdOrden, IdAyuda y Cantidad");
                    return;
                }

                OrdenAyudaDiagnostica nueva = new OrdenAyudaDiagnostica {
                    IdOrden = idOrden,
                    IdAyuda = idAyuda,
                    Cantidad = cantidad
                };

                ordenAyudaBL.RegistrarOrdenAyuda(nueva);
                MessageBox.Show("Orden de ayuda diagnóstica registrada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (!int.TryParse(txtIdOrdenAyuda.Text, out int id)) {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var ayudas = ordenAyudaBL.ObtenerOrdenesAyuda();
            var ayuda = ayudas.FirstOrDefault(a => a.IdOrdenAyuda == id);

            if (ayuda != null) {
                txtIdOrden.Text = ayuda.IdOrden.ToString();
                txtIdAyuda.Text = ayuda.IdAyuda.ToString();
                txtCantidad.Text = ayuda.Cantidad.ToString();
            } else {
                MessageBox.Show("Orden de ayuda diagnóstica no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenAyuda.Text, out int idOrdenAyuda) ||
                    !int.TryParse(txtIdOrden.Text, out int idOrden) ||
                    !int.TryParse(txtIdAyuda.Text, out int idAyuda) ||
                    !int.TryParse(txtCantidad.Text, out int cantidad)) {
                    MessageBox.Show("Debe ingresar valores numéricos válidos");
                    return;
                }

                OrdenAyudaDiagnostica ayuda = new OrdenAyudaDiagnostica {
                    IdOrdenAyuda = idOrdenAyuda,
                    IdOrden = idOrden,
                    IdAyuda = idAyuda,
                    Cantidad = cantidad
                };

                ordenAyudaBL.ActualizarOrdenAyuda(ayuda);
                MessageBox.Show("Orden de ayuda diagnóstica actualizada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenAyuda.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para eliminar");
                    return;
                }

                ordenAyudaBL.EliminarOrdenAyuda(id);
                MessageBox.Show("Orden de ayuda diagnóstica eliminada correctamente");

                // Limpiar campos
                txtIdOrden.Clear();
                txtIdAyuda.Clear();
                txtCantidad.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}