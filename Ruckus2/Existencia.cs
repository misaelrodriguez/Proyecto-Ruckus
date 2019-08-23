using System;
using System.Windows.Forms;


namespace Ruckus2
{
    public partial class Existencia : Form
    {
        Funciones fn = new Funciones();

        public Existencia()
        {
            InitializeComponent();
        }

        private void Existencia_Load(object sender, EventArgs e)
        {
            dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Existencias");
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Existencias");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Existencias WHERE No_parte = '" + textNum.Text + "'");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Existencias (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, CostoUnitario, CantidadMin, CantidadMax, Usuario) VALUES('" + textNum.Text + "', '" + textDes.Text + "', '" + textMode.Text + "', '" + comboCat.Text + "', '" + textLocal.Text + "', '" + textCant.Text + "', '" + textCosto.Text + "','" + textMin.Text + "','" + textMax.Text + "','" + textUser.Text + "')";

            if (fn.Insertar(query))
            {
                MessageBox.Show("Agregado con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Existencias");
            }
            else
            {
                MessageBox.Show("Error al Agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Existencias SET Descripcion = '" + textDes.Text + "', Modelo = '" + textMode.Text + "', Categoria = '" + comboCat.Text + "', Localidad = '" + textLocal.Text + "', Cantidad = '" + textCant.Text + "', CostoUnitario = '" + textCosto.Text + "', CantidadMin = '" + textMin.Text + "', CantidadMax = '" + textMax.Text + "', Usuario = '" + textUser.Text + "' WHERE No_parte = '" + textNum.Text + "'";

            if (fn.Actualizar(query))
            {
                MessageBox.Show("Registro actualiado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Existencias");
            }
            else
            {
                MessageBox.Show("Error al actualizar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (fn.Eliminar("Existencias", "No_parte = '" + textNum.Text + "'"))
            {
                MessageBox.Show("Registro eliminado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Existencias");
            }
            else
            {
                MessageBox.Show("Error al eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textNum.Clear();
            textDes.Clear();
            textMode.Clear();
            textCant.Clear();
            textCosto.Clear();
            textMax.Clear();
            textMin.Clear();
            textLocal.Clear();
            textUser.Clear();
            comboCat.SelectedIndex = -1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dgv_Registros.Rows[e.RowIndex];

            textNum.Text = dgv.Cells[0].Value.ToString();
            textDes.Text = dgv.Cells[1].Value.ToString();
            textMode.Text = dgv.Cells[2].Value.ToString();
            comboCat.Text = dgv.Cells[3].Value.ToString();
            textLocal.Text = dgv.Cells[4].Value.ToString();
            textCant.Text = dgv.Cells[5].Value.ToString();
            textCosto.Text = dgv.Cells[6].Value.ToString();
            textMin.Text = dgv.Cells[7].Value.ToString();
            textMax.Text = dgv.Cells[8].Value.ToString();
            textUser.Text = dgv.Cells[9].Value.ToString();
        }
    }
}
