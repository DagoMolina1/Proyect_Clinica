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
    public partial class OrdenProcedimientoForm : Form {

        private OrdenProcedimientoBL ordenProcBL = new OrdenProcedimientoBL();

        public OrdenProcedimientoForm() {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrden.Text, out int idOrden) ||
                    !int.TryParse(txtIdProcedimiento.Text, out int idProcedimiento) ||
                    !int.TryParse(txtRepeticiones.Text, out int repeticiones)) {
                    MessageBox.Show("Debe ingresar valores numéricos válidos en IdOrden, IdProcedimiento y Repeticiones");
                    return;
                }

                OrdenProcedimiento nuevo = new OrdenProcedimiento {
                    IdOrden = idOrden,
                    IdProcedimiento = idProcedimiento,
                    Repeticiones = repeticiones,
                    Frecuencia = txtFrecuencia.Text
                };

                ordenProcBL.RegistrarOrdenProcedimiento(nuevo);
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

            var procedimientos = ordenProcBL.ObtenerOrdenProcedimientos();
            var proc = procedimientos.FirstOrDefault(p => p.IdOrdenProcedimiento == id);

            if (proc != null) {
                txtIdOrden.Text = proc.IdOrden.ToString();
                txtIdProcedimiento.Text = proc.IdProcedimiento.ToString();
                txtRepeticiones.Text = proc.Repeticiones.ToString();
                txtFrecuencia.Text = proc.Frecuencia;
            } else {
                MessageBox.Show("❌ Orden de procedimiento no encontrada");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdOrdenProcedimiento.Text, out int idOrdenProc) ||
                    !int.TryParse(txtIdOrden.Text, out int idOrden) ||
                    !int.TryParse(txtIdProcedimiento.Text, out int idProcedimiento) ||
                    !int.TryParse(txtRepeticiones.Text, out int repeticiones)) {
                    MessageBox.Show("Debe ingresar valores numéricos válidos");
                    return;
                }

                OrdenProcedimiento proc = new OrdenProcedimiento {
                    IdOrdenProcedimiento = idOrdenProc,
                    IdOrden = idOrden,
                    IdProcedimiento = idProcedimiento,
                    Repeticiones = repeticiones,
                    Frecuencia = txtFrecuencia.Text
                };

                ordenProcBL.ActualizarOrdenProcedimiento(proc);
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

                ordenProcBL.EliminarOrdenProcedimiento(id);
                MessageBox.Show("❌ Orden de procedimiento eliminada correctamente");

                // Limpiar campos
                txtIdOrden.Clear();
                txtIdProcedimiento.Clear();
                txtRepeticiones.Clear();
                txtFrecuencia.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}