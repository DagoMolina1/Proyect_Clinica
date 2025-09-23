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
    public partial class FacturacionForm : Form {

        private FacturacionBL facturacionBL = new FacturacionBL();

        public FacturacionForm() {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdPaciente.Text, out int idPaciente) ||
                    !int.TryParse(txtIdMedico.Text, out int idMedico)) {
                    MessageBox.Show("Debe ingresar un Id válido para Paciente y Médico");
                    return;
                }

                decimal totalServicios = decimal.Parse(txtTotal.Text); // supongamos que viene de la UI
                bool polizaActiva = !string.IsNullOrEmpty(txtIdSeguro.Text);
                decimal copagosAcumulados = 0; // aquí podrías calcular lo acumulado del paciente

                Facturacion factura = new Facturacion {
                    IdPaciente = idPaciente,
                    IdMedico = idMedico,
                    IdSeguro = string.IsNullOrEmpty(txtIdSeguro.Text) ? (int?)null : int.Parse(txtIdSeguro.Text)
                };

                facturacionBL.GenerarFactura(factura, totalServicios, polizaActiva, copagosAcumulados);

                MessageBox.Show("Factura generada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)  {
            if (!int.TryParse(txtIdFactura.Text, out int id)) {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var facturas = facturacionBL.ObtenerFacturas();
            var factura = facturas.FirstOrDefault(f => f.IdFactura == id);

            if (factura != null) {
                dtpFecha.Value = factura.Fecha;
                txtCopago.Text = factura.Copago.ToString();
                txtTotal.Text = factura.Total.ToString();
                txtIdPaciente.Text = factura.IdPaciente.ToString();
                txtIdMedico.Text = factura.IdMedico.ToString();
                txtIdSeguro.Text = factura.IdSeguro?.ToString() ?? "";
            } else {
                MessageBox.Show("Factura no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdFactura.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para modificar");
                    return;
                }

                Facturacion factura = new Facturacion {
                    IdFactura = id,
                    Fecha = dtpFecha.Value,
                    Copago = decimal.Parse(txtCopago.Text),
                    Total = decimal.Parse(txtTotal.Text),
                    IdPaciente = int.Parse(txtIdPaciente.Text),
                    IdMedico = int.Parse(txtIdMedico.Text),
                    IdSeguro = string.IsNullOrEmpty(txtIdSeguro.Text) ? (int?)null : int.Parse(txtIdSeguro.Text)
                };

                facturacionBL.ActualizarFactura(factura);
                MessageBox.Show("Factura actualizada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdFactura.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para eliminar");
                    return;
                }

                facturacionBL.EliminarFactura(id);
                MessageBox.Show("Factura eliminada correctamente");

                // Limpiar campos
                txtCopago.Clear();
                txtTotal.Clear();
                txtIdPaciente.Clear();
                txtIdMedico.Clear();
                txtIdSeguro.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}