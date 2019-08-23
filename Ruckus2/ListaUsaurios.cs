using System;
using System.Windows.Forms;

namespace Ruckus2
{
    public partial class ListaUsaurios : Form
    {
        Funciones fn = new Funciones();

        public ListaUsaurios()
        {
            InitializeComponent();
        }

        private void ListaUsaurios_Load(object sender, EventArgs e)
        {
            dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Usuarios");
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string agregar = "INSERT INTO Usuarios VALUES ( '" + textUser.Text + "', '" + textNom.Text + "','" + textCon.Text + "','" + comboTipo.Text + "')";

            if (fn.Insertar(agregar))
            {
                MessageBox.Show("Registro con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Usuarios");
            }
            else
            {
                MessageBox.Show("Error al registrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string actualizar = "UPDATE Usuarios SET Nombre= '" + textNom.Text + "', Contrasena= '" + textCon.Text + "', Tipo_user= '" + comboTipo.Text + "' WHERE Id_user = '" + textUser.Text + "' ";

            if (fn.Actualizar(actualizar))
            {
                MessageBox.Show("Registro actualizado", "Correto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Usuarios");
            }
            else
            {
                MessageBox.Show("Error al actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (fn.Eliminar("Usuarios", "Id_user = '" + textUser.Text + "'"))
            {
                MessageBox.Show("Registro eliminado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Usuarios");
            }
            else
            {
                MessageBox.Show("Error al eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textUser.Clear();
            textNom.Clear();
            textCon.Clear();
            comboTipo.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Registros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dgv_Registros.Rows[e.RowIndex];
            textUser.Text = dgv.Cells[0].Value.ToString();
            textNom.Text = dgv.Cells[1].Value.ToString();
            textCon.Text = dgv.Cells[2].Value.ToString();
            comboTipo.Text = dgv.Cells[3].Value.ToString();
        }
    }
}
