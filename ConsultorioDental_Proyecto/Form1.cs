using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioDental_Proyecto
{
    public partial class Form1 : Form
    {

        
        System.Collections.Generic.List<Cita> listaCitas = new System.Collections.Generic.List<Cita>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtPaciente.Text) ||
                string.IsNullOrWhiteSpace(txtHora.Text) ||
                cmbMotivo.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos con * son obligatorios.");
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtPaciente.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Por favor, llena el ID y el Nombre.");
                    return;
                }

                if (listaCitas.Exists(x => x.ID == txtID.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Este ID ya existe. Usa uno diferente.");
                    return;
                }

                Cita nuevaCita = new Cita
                {
                    ID = txtID.Text,
                    Paciente = txtPaciente.Text,
                    Fecha = dtpFecha.Value,
                    Hora = txtHora.Text,
                    Dentista = txtDentista.Text,
                    Motivo = cmbMotivo.Text
                };

                listaCitas.Add(nuevaCita);
                dgvCitas.DataSource = null; // Truco para refrescar
                dgvCitas.DataSource = listaCitas;

                System.Windows.Forms.MessageBox.Show("Cita agendada con éxito.");

                txtID.Clear();
                txtPaciente.Clear();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Escribe el ID de la cita que deseas eliminar.");
                    return;
                }

                Cita citaAEliminar = listaCitas.Find(x => x.ID == txtID.Text);

                if (citaAEliminar != null)
                {
                    // --- ESTO ES LO NUEVO: Una pregunta de seguridad ---
                    DialogResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar la cita de {citaAEliminar.Paciente}?",
                        "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        listaCitas.Remove(citaAEliminar);

                        // Refrescar el Grid
                        dgvCitas.DataSource = null;
                        dgvCitas.DataSource = listaCitas;

                        MessageBox.Show("Cita eliminada correctamente.");

                        // Limpiamos los campos para que queden vacíos
                        txtID.Clear();
                        txtPaciente.Clear();
                        txtHora.Clear();
                        txtDentista.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna cita con ese ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cita citaAEditar = listaCitas.Find(x => x.ID == txtID.Text);

                if (citaAEditar != null)
                {
                    citaAEditar.Paciente = txtPaciente.Text;
                    citaAEditar.Fecha = dtpFecha.Value;
                    citaAEditar.Hora = txtHora.Text;
                    citaAEditar.Dentista = txtDentista.Text;
                    citaAEditar.Motivo = cmbMotivo.Text;

                    dgvCitas.DataSource = null;
                    dgvCitas.DataSource = listaCitas;

                    MessageBox.Show("Cita actualizada con éxito.");
                }
                else
                {
                    MessageBox.Show("No se puede actualizar: El ID no existe.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = dgvCitas.Rows[e.RowIndex];

                    // Asignamos los valores de la fila a los cuadros de texto
                    txtID.Text = fila.Cells["ID"].Value.ToString();
                    txtPaciente.Text = fila.Cells["Paciente"].Value.ToString();
                    txtHora.Text = fila.Cells["Hora"].Value.ToString();
                    txtDentista.Text = fila.Cells["Dentista"].Value.ToString();
                    cmbMotivo.Text = fila.Cells["Motivo"].Value.ToString();
                    dtpFecha.Value = Convert.ToDateTime(fila.Cells["Fecha"].Value);
                }
                catch { /* Si falta algún dato, que no explote */ }
            }
        }
    }
}
