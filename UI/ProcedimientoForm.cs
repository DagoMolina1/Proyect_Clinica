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
    public partial class ProcedimientoForm: Form {

        private ProcedimientoBL procedimientoBL = new ProcedimientoBL();

        public ProcedimientoForm() {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtNombre.Text)) {
                    MessageBox.Show("El nombre es obligatorio");
                    return;
                }

                if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo <= 0) {
                    MessageBox.Show("El costo debe ser mayor a 0");
                    return;
                }

                Procedimiento nuevo = new Procedimiento {
                    Nombre = txtNombre.Text,
                    Costo = costo,
                    RequiereEspecialista = chkEspecialista.Checked,
                    IdEspecialidad = string.IsNullOrWhiteSpace(txtIdEspecialidad.Text) 
                        ? (int?)null 
                        : int.Parse(txtIdEspecialidad.Text)
                };

                procedimientoBL.RegistrarProcedimiento(nuevo);
                MessageBox.Show("Procedimiento registrado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e) {
            if (!int.TryParse(txtIdProcedimiento.Text, out int id)) {
                MessageBox.Show("Ingrese un ID válido");
                return;
            }

            var procedimientos = procedimientoBL.ObtenerProcedimientos();
            var procedimiento = procedimientos.FirstOrDefault(p => p.IdProcedimiento == id);

            if (procedimiento != null) {
                txtNombre.Text = procedimiento.Nombre;
                txtCosto.Text = procedimiento.Costo.ToString();
                chkEspecialista.Checked = procedimiento.RequiereEspecialista;
                txtIdEspecialidad.Text = procedimiento.IdEspecialidad?.ToString() ?? "";
            } else {
                MessageBox.Show("❌ Procedimiento no encontrado");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdProcedimiento.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para modificar");
                    return;
                }

                if (!decimal.TryParse(txtCosto.Text, out decimal costo) || costo <= 0) {
                    MessageBox.Show("El costo debe ser mayor a 0");
                    return;
                }

                Procedimiento procedimiento = new Procedimiento {
                    IdProcedimiento = id,
                    Nombre = txtNombre.Text,
                    Costo = costo,
                    RequiereEspecialista = chkEspecialista.Checked,
                    IdEspecialidad = string.IsNullOrWhiteSpace(txtIdEspecialidad.Text) ? (int?)null : int.Parse(txtIdEspecialidad.Text)
                };

                procedimientoBL.ActualizarProcedimiento(procedimiento);
                MessageBox.Show("Procedimiento actualizado correctamente");
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (!int.TryParse(txtIdProcedimiento.Text, out int id)) {
                    MessageBox.Show("Ingrese un ID válido para eliminar");
                    return;
                }

                procedimientoBL.EliminarProcedimiento(id);
                MessageBox.Show("Procedimiento eliminado correctamente");

                // Limpieza de campos
                txtNombre.Clear();
                txtCosto.Clear();
                chkEspecialista.Checked = false;
                txtIdEspecialidad.Clear();
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
