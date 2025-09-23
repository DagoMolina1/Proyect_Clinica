using System;
using System.Linq;
using System.Windows.Forms;
using ClinicaIPS_U.Domain.Entities;
using ClinicaIPS_U.Domain.Services;

namespace ClinicaIPS_U.UI {
    public partial class OrdenForm : Form {
        private readonly OrdenService _ordenService;

        public OrdenForm(OrdenService ordenService) {
            InitializeComponent();
            _ordenService = ordenService;
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrden.Text, out int idOrden)) {
                    MessageBox.Show("Debe ingresar un número de orden válido (máximo 6 dígitos)");
                    return;
                }

                if (!int.TryParse(txtIdPaciente.Text, out int idPaciente) ||
                    !int.TryParse(txtIdMedico.Text, out int idMedico)) {
                    MessageBox.Show("Debe ingresar Id válidos para paciente y médico");
                    return;
                }

                Orden nueva = new Orden {
                    IdOrden = idOrden,
                    IdPaciente = idPaciente,
                    IdMedico = idMedico,
                    FechaCreacion = DateTime.Now
                };

                _ordenService.RegistrarOrden(nueva);
                MessageBox.Show("Orden registrada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (!int.TryParse(txtIdOrden.Text, out int id)) {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var orden = _ordenService.BuscarOrden(id);

            if (orden != null) {
                dtpFecha.Value = orden.FechaCreacion;
                txtIdPaciente.Text = orden.IdPaciente.ToString();
                txtIdMedico.Text = orden.IdMedico.ToString();
            } else {
                MessageBox.Show("Orden no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrden.Text, out int idOrden)) {
                    MessageBox.Show("Ingrese un ID válido para modificar");
                    return;
                }

                if (!int.TryParse(txtIdPaciente.Text, out int idPaciente) ||
                    !int.TryParse(txtIdMedico.Text, out int idMedico)) {
                    MessageBox.Show("Ingrese Id válidos para Paciente y Médico");
                    return;
                }

                Orden orden = new Orden {
                    IdOrden = idOrden,
                    FechaCreacion = dtpFecha.Value,
                    IdPaciente = idPaciente,
                    IdMedico = idMedico
                };

                _ordenService.ActualizarOrden(orden);
                MessageBox.Show("Orden actualizada correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrden.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para eliminar");
                    return;
                }

                _ordenService.EliminarOrden(id);
                MessageBox.Show("Orden eliminada correctamente");
                txtIdPaciente.Clear();
                txtIdMedico.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
