using System;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Services;

namespace ClinicaIPS_U.UI {
    public partial class OrdenMedicamentoForm : Form {
        private readonly OrdenService _ordenService;
        private readonly MedicamentoService _medicamentoService;

        public OrdenMedicamentoForm(OrdenService ordenService, MedicamentoService medicamentoService) {
            InitializeComponent();
            _ordenService = ordenService;
            _medicamentoService = medicamentoService;
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                var ordenMedicamento = ConstruirOrdenMedicamento();
                _ordenService.RegistrarOrdenMedicamento(ordenMedicamento);
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

            var ordenMed = _ordenService.BuscarOrdenMedicamento(id);

            if (ordenMed != null) {
                txtIdOrden.Text = ordenMed.IdOrden.ToString();
                txtNumeroItem.Text = ordenMed.NumeroItem.ToString();
                txtIdMedicamento.Text = ordenMed.IdMedicamento.ToString();
                txtNombreMedicamento.Text = ordenMed.NombreMedicamento;
                txtDosis.Text = ordenMed.Dosis;
                txtDuracion.Text = ordenMed.DuracionTratamiento;
                txtCantidad.Text = ordenMed.Cantidad.ToString();
                txtCostoUnitario.Text = ordenMed.CostoUnitario.ToString();
            } else {
                MessageBox.Show("Orden de medicamento no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenMedicamento.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para modificar");
                    return;
                }

                var ordenMed = ConstruirOrdenMedicamento();
                ordenMed.IdOrdenMedicamento = id;
                _ordenService.ActualizarOrdenMedicamento(ordenMed);
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

                _ordenService.EliminarOrdenMedicamento(id);
                MessageBox.Show("Orden de medicamento eliminada correctamente");
                LimpiarFormulario();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private OrdenMedicamento ConstruirOrdenMedicamento() {
            if (!int.TryParse(txtIdOrden.Text, out int idOrden) ||
                !int.TryParse(txtNumeroItem.Text, out int numeroItem) ||
                !int.TryParse(txtIdMedicamento.Text, out int idMedicamento) ||
                !int.TryParse(txtCantidad.Text, out int cantidad)) {
                throw new InvalidOperationException("Id de orden, número de ítem, medicamento y cantidad deben ser numéricos.");
            }

            if (!decimal.TryParse(txtCostoUnitario.Text, out decimal costo) || costo <= 0) {
                throw new InvalidOperationException("El costo unitario debe ser mayor a cero.");
            }

            var catalogo = _medicamentoService.BuscarPorId(idMedicamento);

            var nombreMedicamento = string.IsNullOrWhiteSpace(txtNombreMedicamento.Text)
                ? catalogo?.Nombre ?? string.Empty
                : txtNombreMedicamento.Text;

            var dosis = string.IsNullOrWhiteSpace(txtDosis.Text)
                ? catalogo?.Dosis
                : txtDosis.Text;

            if (string.IsNullOrWhiteSpace(nombreMedicamento)) {
                throw new InvalidOperationException("Debe especificar el nombre del medicamento.");
            }

            return new OrdenMedicamento {
                IdOrden = idOrden,
                NumeroItem = numeroItem,
                IdMedicamento = idMedicamento,
                NombreMedicamento = nombreMedicamento,
                Dosis = dosis,
                DuracionTratamiento = txtDuracion.Text,
                Cantidad = cantidad,
                CostoUnitario = costo
            };
        }

        private void LimpiarFormulario() {
            txtIdOrden.Clear();
            txtNumeroItem.Clear();
            txtIdMedicamento.Clear();
            txtNombreMedicamento.Clear();
            txtDosis.Clear();
            txtDuracion.Clear();
            txtCantidad.Clear();
            txtCostoUnitario.Clear();
        }
    }
}
