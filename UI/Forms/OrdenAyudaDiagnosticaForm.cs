using System;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Services;

namespace ClinicaIPS_U.UI {
    public partial class OrdenAyudaDiagnosticaForm : Form {
        private readonly OrdenService _ordenService;
        private readonly AyudaDiagnosticaService _ayudaService;

        public OrdenAyudaDiagnosticaForm(OrdenService ordenService, AyudaDiagnosticaService ayudaService) {
            InitializeComponent();
            _ordenService = ordenService;
            _ayudaService = ayudaService;
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                var ordenAyuda = ConstruirOrdenAyuda();
                _ordenService.RegistrarOrdenAyuda(ordenAyuda);
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

            var orden = _ordenService.BuscarOrdenAyuda(id);

            if (orden != null) {
                txtIdOrden.Text = orden.IdOrden.ToString();
                txtNumeroItem.Text = orden.NumeroItem.ToString();
                txtIdAyuda.Text = orden.IdAyuda.ToString();
                txtNombreAyuda.Text = orden.NombreAyuda;
                txtCantidad.Text = orden.Cantidad.ToString();
                chkRequiereEspecialista.Checked = orden.RequiereEspecialista;
                txtIdEspecialidad.Text = orden.IdEspecialidad?.ToString() ?? string.Empty;
                txtCostoUnitario.Text = orden.CostoUnitario.ToString();
            } else {
                MessageBox.Show("Orden de ayuda diagnóstica no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenAyuda.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para modificar");
                    return;
                }

                var orden = ConstruirOrdenAyuda();
                orden.IdOrdenAyuda = id;
                _ordenService.ActualizarOrdenAyuda(orden);
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

                _ordenService.EliminarOrdenAyuda(id);
                MessageBox.Show("Orden de ayuda diagnóstica eliminada correctamente");
                LimpiarFormulario();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private OrdenAyudaDiagnostica ConstruirOrdenAyuda() {
            if (!int.TryParse(txtIdOrden.Text, out int idOrden) ||
                !int.TryParse(txtNumeroItem.Text, out int numeroItem) ||
                !int.TryParse(txtIdAyuda.Text, out int idAyuda) ||
                !int.TryParse(txtCantidad.Text, out int cantidad)) {
                throw new InvalidOperationException("Los valores numéricos de la orden deben ser válidos.");
            }

            if (!decimal.TryParse(txtCostoUnitario.Text, out decimal costo) || costo <= 0) {
                throw new InvalidOperationException("El costo unitario debe ser mayor a cero.");
            }

            var ayudaCatalogo = _ayudaService.BuscarPorId(idAyuda);
            var nombreAyuda = string.IsNullOrWhiteSpace(txtNombreAyuda.Text)
                ? ayudaCatalogo?.Nombre ?? string.Empty
                : txtNombreAyuda.Text;

            if (string.IsNullOrWhiteSpace(nombreAyuda)) {
                throw new InvalidOperationException("Debe especificar el nombre de la ayuda diagnóstica.");
            }

            int? idEspecialidad = null;
            if (int.TryParse(txtIdEspecialidad.Text, out int idEsp)) {
                idEspecialidad = idEsp;
            }

            return new OrdenAyudaDiagnostica {
                IdOrden = idOrden,
                NumeroItem = numeroItem,
                IdAyuda = idAyuda,
                NombreAyuda = nombreAyuda,
                Cantidad = cantidad,
                RequiereEspecialista = chkRequiereEspecialista.Checked,
                IdEspecialidad = idEspecialidad,
                CostoUnitario = costo
            };
        }

        private void LimpiarFormulario() {
            txtIdOrden.Clear();
            txtNumeroItem.Clear();
            txtIdAyuda.Clear();
            txtNombreAyuda.Clear();
            txtCantidad.Clear();
            chkRequiereEspecialista.Checked = false;
            txtIdEspecialidad.Clear();
            txtCostoUnitario.Clear();
        }
    }
}
