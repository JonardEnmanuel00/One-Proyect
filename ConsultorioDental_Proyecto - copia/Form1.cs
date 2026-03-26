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
    }
}
