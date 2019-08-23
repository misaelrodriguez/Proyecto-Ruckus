using System;
using System.Windows.Forms;

namespace Ruckus2
{
    public partial class Movimientos : Form
    {
        Funciones fn = new Funciones();

        public Movimientos()
        {
            InitializeComponent();
        }

        private void Movimientos_Load(object sender, EventArgs e)
        {
            dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Movimientos");
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Movimientos");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Movimientos WHERE Id_mov = '" + textIdmov.Text + "'");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (fn.Eliminar("Movimientos", "Id_mov = '" + textIdmov.Text + "'"))
            {
                MessageBox.Show("Registro eliminado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Movimientos");
            }
            else
            {
                MessageBox.Show("Error al eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textIdmov.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
