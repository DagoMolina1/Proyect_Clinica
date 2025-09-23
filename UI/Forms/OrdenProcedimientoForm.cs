using System;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Services;

namespace ClinicaIPS_U.UI {
    public partial class OrdenProcedimientoForm : Form {
        private readonly OrdenService _ordenService;
        private readonly ProcedimientoService _procedimientoService;

        public OrdenProcedimientoForm(OrdenService ordenService, ProcedimientoService procedimientoService) {
            InitializeComponent();
            _ordenService = ordenService;
            _procedimientoService = procedimientoService;
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                var ordenProc = ConstruirOrdenProcedimiento();
                _ordenService.RegistrarOrdenProcedimiento(ordenProc);
                MessageBox.Show("Orden de procedimiento registrada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (!int.TryParse(txtIdOrdenProcedimiento.Text, out int id)) {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var orden = _ordenService.BuscarOrdenProcedimiento(id);

            if (orden != null) {
                txtIdOrden.Text = orden.IdOrden.ToString();
                txtNumeroItem.Text = orden.NumeroItem.ToString();
                txtIdProcedimiento.Text = orden.IdProcedimiento.ToString();
                txtNombreProcedimiento.Text = orden.NombreProcedimiento;
                txtVeces.Text = orden.Veces.ToString();
                txtFrecuencia.Text = orden.Frecuencia;
                chkRequiereEspecialista.Checked = orden.RequiereEspecialista;
                txtIdEspecialidad.Text = orden.IdEspecialidad?.ToString() ?? string.Empty;
                txtCostoUnitario.Text = orden.CostoUnitario.ToString();
            } else {
                MessageBox.Show("Orden de procedimiento no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenProcedimiento.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para modificar");
                    return;
                }

                var orden = ConstruirOrdenProcedimiento();
                orden.IdOrdenProcedimiento = id;
                _ordenService.ActualizarOrdenProcedimiento(orden);
                MessageBox.Show("Orden de procedimiento actualizada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenProcedimiento.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para eliminar");
                    return;
                }

                _ordenService.EliminarOrdenProcedimiento(id);
                MessageBox.Show("Orden de procedimiento eliminada correctamente");
                LimpiarFormulario();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private OrdenProcedimiento ConstruirOrdenProcedimiento() {
            if (!int.TryParse(txtIdOrden.Text, out int idOrden) ||
                !int.TryParse(txtNumeroItem.Text, out int numeroItem) ||
                !int.TryParse(txtIdProcedimiento.Text, out int idProcedimiento) ||
                !int.TryParse(txtVeces.Text, out int veces)) {
                throw new InvalidOperationException("Id de orden, número de ítem, procedimiento y número de veces deben ser numéricos.");
            }

            if (!decimal.TryParse(txtCostoUnitario.Text, out decimal costo) || costo <= 0) {
                throw new InvalidOperationException("El costo unitario debe ser mayor a cero.");
            }

            var catalogo = _procedimientoService.BuscarPorId(idProcedimiento);
            var nombreProcedimiento = string.IsNullOrWhiteSpace(txtNombreProcedimiento.Text)
                ? catalogo?.Nombre ?? string.Empty
                : txtNombreProcedimiento.Text;

            if (string.IsNullOrWhiteSpace(nombreProcedimiento)) {
                throw new InvalidOperationException("Debe especificar el nombre del procedimiento.");
            }

            int? idEspecialidad = null;
            if (int.TryParse(txtIdEspecialidad.Text, out int idEsp)) {
                idEspecialidad = idEsp;
            }

            return new OrdenProcedimiento {
                IdOrden = idOrden,
                NumeroItem = numeroItem,
                IdProcedimiento = idProcedimiento,
                NombreProcedimiento = nombreProcedimiento,
                Veces = veces,
                Frecuencia = txtFrecuencia.Text,
                RequiereEspecialista = chkRequiereEspecialista.Checked,
                IdEspecialidad = idEspecialidad,
                CostoUnitario = costo
            };
        }

        private void LimpiarFormulario() {
            txtIdOrden.Clear();
            txtNumeroItem.Clear();
            txtIdProcedimiento.Clear();
            txtNombreProcedimiento.Clear();
            txtVeces.Clear();
            txtFrecuencia.Clear();
            chkRequiereEspecialista.Checked = false;
            txtIdEspecialidad.Clear();
            txtCostoUnitario.Clear();
        }
    }
}
