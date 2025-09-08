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
    public partial class OrdenMedicamentoForm : Form {

        private OrdenMedicamentoBL ordenMedicamentoBL = new OrdenMedicamentoBL();

        public OrdenMedicamentoForm() {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrden.Text, out int idOrden) ||
                    !int.TryParse(txtIdMedicamento.Text, out int idMedicamento) ||
                    !int.TryParse(txtCantidad.Text, out int cantidad)) {
                    MessageBox.Show("Debe ingresar valores numéricos válidos para IdOrden, IdMedicamento y Cantidad");
                    return;
                }

                OrdenMedicamento nuevo = new OrdenMedicamento {
                    IdOrden = idOrden,
                    IdMedicamento = idMedicamento,
                    Cantidad = cantidad
                };

                ordenMedicamentoBL.RegistrarOrdenMedicamento(nuevo);
                MessageBox.Show("Orden de medicamento registrada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (!int.TryParse(txtIdOrdenMedicamento.Text, out int id)) {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var ordenes = ordenMedicamentoBL.ObtenerOrdenMedicamentos();
            var ordenMed = ordenes.FirstOrDefault(o => o.IdOrdenMedicamento == id);

            if (ordenMed != null) {
                txtIdOrden.Text = ordenMed.IdOrden.ToString();
                txtIdMedicamento.Text = ordenMed.IdMedicamento.ToString();
                txtCantidad.Text = ordenMed.Cantidad.ToString();
            } else {
                MessageBox.Show("Orden de medicamento no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenMedicamento.Text, out int idOrdenMed) ||
                    !int.TryParse(txtIdOrden.Text, out int idOrden) ||
                    !int.TryParse(txtIdMedicamento.Text, out int idMedicamento) ||
                    !int.TryParse(txtCantidad.Text, out int cantidad)) {
                    MessageBox.Show("Debe ingresar valores numéricos válidos");
                    return;
                }

                OrdenMedicamento ordenMed = new OrdenMedicamento {
                    IdOrdenMedicamento = idOrdenMed,
                    IdOrden = idOrden,
                    IdMedicamento = idMedicamento,
                    Cantidad = cantidad
                };

                ordenMedicamentoBL.ActualizarOrdenMedicamento(ordenMed);
                MessageBox.Show("Orden de medicamento actualizada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenMedicamento.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para eliminar");
                    return;
                }

                ordenMedicamentoBL.EliminarOrdenMedicamento(id);
                MessageBox.Show("Orden de medicamento eliminada correctamente");

                // Limpiar campos
                txtIdOrden.Clear();
                txtIdMedicamento.Clear();
                txtCantidad.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}