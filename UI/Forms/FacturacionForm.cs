using System;
using System.Text;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Services;
using ClinicaIPS_U.Infrastructure.Configuration;

namespace ClinicaIPS_U.UI {
    public partial class FacturacionForm : Form {
        private readonly AppServiceProvider _services;

        public FacturacionForm(AppServiceProvider services) {
            InitializeComponent();
            _services = services;
        }

        private void btnGenerar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrden.Text, out int idOrden)) {
                    MessageBox.Show("Debe ingresar un número de orden válido");
                    return;
                }

                bool registrar = chkRegistrar.Checked;
                var detalle = _services.Facturacion.GenerarFactura(idOrden, registrar);

                txtPaciente.Text = detalle.NombrePaciente;
                txtCedula.Text = detalle.CedulaPaciente;
                txtEdad.Text = detalle.EdadPaciente.ToString();
                txtMedico.Text = detalle.NombreMedicoTratante;
                txtAseguradora.Text = detalle.NombreAseguradora;
                txtPoliza.Text = detalle.NumeroPoliza;
                txtEstadoPoliza.Text = detalle.PolizaActiva ? "Activa" : "Inactiva";
                txtDiasVigencia.Text = detalle.DiasVigencia.ToString();
                txtFechaFin.Text = detalle.FechaFinPoliza.ToShortDateString();
                txtCopago.Text = detalle.Copago.ToString("N0");
                txtTotalServicios.Text = detalle.TotalServicios.ToString("N0");
                txtValorPaciente.Text = detalle.ValorPaciente.ToString("N0");
                txtValorAseguradora.Text = detalle.ValorCoberturaAseguradora.ToString("N0");

                lstDetalle.Items.Clear();
                foreach (var med in detalle.Medicamentos) {
                    lstDetalle.Items.Add($"Medicamento #{med.NumeroItem}: {med.NombreMedicamento} x{med.Cantidad} - {med.Subtotal:C}");
                }
                foreach (var proc in detalle.Procedimientos) {
                    lstDetalle.Items.Add($"Procedimiento #{proc.NumeroItem}: {proc.NombreProcedimiento} ({proc.Veces} veces) - {proc.Subtotal:C}");
                }
                foreach (var ayuda in detalle.AyudasDiagnosticas) {
                    lstDetalle.Items.Add($"Ayuda #{ayuda.NumeroItem}: {ayuda.NombreAyuda} x{ayuda.Cantidad} - {ayuda.Subtotal:C}");
                }

                MessageBox.Show(registrar
                    ? "Factura generada y registrada correctamente"
                    : "Factura generada correctamente (sin registrar)");
            } catch (Exception ex) {
                MessageBox.Show($"Error al generar la factura: {ex.Message}");
            }
        }
    }
}
