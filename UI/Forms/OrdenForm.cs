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
    public partial class OrdenForm : Form {

        private OrdenBL ordenBL = new OrdenBL();

        public OrdenForm() {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdPaciente.Text, out int idPaciente)) {
                    MessageBox.Show("Debe ingresar un Id de paciente válido");
                    return;
                }

                if (!int.TryParse(txtIdMedico.Text, out int idMedico)) {
                    MessageBox.Show("Debe ingresar un Id de médico válido");
                    return;
                }

                Orden nueva = new Orden {
                    IdPaciente = idPaciente,
                    IdMedico = idMedico,
                    FechaCreacion = DateTime.Now
                };

                ordenBL.RegistrarOrden(nueva);
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

            var ordenes = ordenBL.ObtenerOrdenes();
            var orden = ordenes.FirstOrDefault(o => o.IdOrden == id);

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

                ordenBL.ActualizarOrden(orden);
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

                ordenBL.EliminarOrden(id);
                MessageBox.Show("Orden eliminada correctamente");

                // Limpiar campos
                txtIdPaciente.Clear();
                txtIdMedico.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}