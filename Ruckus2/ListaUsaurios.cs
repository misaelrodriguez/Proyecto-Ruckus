using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ruckus2
{
    public partial class ListaUsaurios : Form
    {
        public ListaUsaurios()
        {
            InitializeComponent();
        }
        Funciones fn = new Funciones();
        private void ListaUsaurios_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fn.Llenargrid("select * from Usuarios");
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            string agregar = "insert into usuarios values ( '" + textUser.Text + "', '" + textNom.Text + "','" + textCon.Text + "','" + comboBox1.Text + "')";
            if (fn.Insertar(agregar))
            {
                MessageBox.Show("Registro con exito");
                dataGridView1.DataSource = fn.Llenargrid("select * from Usuarios");
            }
            else
            {
                MessageBox.Show("Error al registrar");
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            string actualizar = "update usuarios SET Nombre= '" + textNom.Text + "', Contraseña= '" + textCon.Text + "', Tipo_user= '" + comboBox1.Text + "' Where Id_user = '" + textUser.Text + "' ";
            if (fn.Actualizar(actualizar))
            {
                MessageBox.Show("Registro actualizado");
                dataGridView1.DataSource = fn.Llenargrid("select * from Usuarios");
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
            conexion.Open();
            string eliminar = "Delete from Usuarios Where Id_user = '" + textUser.Text + "' ";
            SqlCommand cmd = new SqlCommand(eliminar);
            SqlDataAdapter mostrar = new SqlDataAdapter(eliminar, conexion);
            DataTable movi = new DataTable();
            mostrar.Fill(movi);
            dataGridView1.DataSource = movi;
            MessageBox.Show("Registro eliminado");
            dataGridView1.DataSource = fn.Llenargrid("select * from Usuarios");

            conexion.Close();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textUser.Clear();
            textNom.Clear();
            textCon.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
            textUser.Text = dgv.Cells[0].Value.ToString();
            textNom.Text = dgv.Cells[1].Value.ToString();
            textCon.Text = dgv.Cells[2].Value.ToString();
            comboBox1.Text = dgv.Cells[3].Value.ToString();
        }
    }
}
