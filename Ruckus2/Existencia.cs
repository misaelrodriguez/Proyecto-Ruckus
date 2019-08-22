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
    public partial class Existencia : Form
    {
        SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
        public Existencia()
        {
            InitializeComponent();
        }
            Funciones fn = new Funciones();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
            conexion.Open();
            string buscar = "Select * from Existencia Where No_parte = '" + textNum.Text + "' ";
            SqlCommand cmd = new SqlCommand(buscar);
            SqlDataAdapter mostrar = new SqlDataAdapter(buscar, conexion);
            DataTable movi = new DataTable();
            mostrar.Fill(movi);
            dgvRegistro.DataSource = movi;
            conexion.Close();
            
        }

        private void Existencia_Load(object sender, EventArgs e)
        {
            dgvRegistro.DataSource = fn.Llenargrid("select * from Existencia");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string agregar = "insert into Existencia (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, CostoUnitario, CantidadMin, CantidadMax, Usuario) values('" + textNum.Text + "','" + textDes.Text + "', '" + textMode.Text + "','" + comboCat.Text + "', '" + textLocal.Text +"', '"+ textCant.Text +"', '" + textCosto.Text +"','"+ textMin.Text +"','"+ textMax.Text +"','" + textUser.Text +"')";
            if (fn.Insertar(agregar))


            {
                MessageBox.Show("Agregado con exito");
                dgvRegistro.DataSource = fn.Llenargrid("select * from Existencia");
            }
            else
            {
                MessageBox.Show("Error al Agregar");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string actualizar = "update Existencia SET Descripcion= '" + textDes.Text + "', Modelo= '" + textMode.Text + "', Categoria= '" + comboCat.Text + "', Localidad= '" + textLocal.Text + "', Cantidad= '" + textCant.Text + "',CostoUnitario= '" + textCosto.Text + "', CantidadMin= '" + textMin.Text + "', CantidadMax= '" + textMax.Text + "', Usuario= '" + textUser.Text + "' WHERE No_parte= '" + textNum.Text + "'";
            if (fn.Actualizar(actualizar))
            {
                MessageBox.Show("Registro actualiado");
                dgvRegistro.DataSource = fn.Llenargrid("select * from Existencia");
            }
            else
            {
                MessageBox.Show("Error al actualizar");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
            conexion.Open();
            string eliminar = "Delete from Existencia Where No_parte = '" + textNum.Text + "' ";
            SqlCommand cmd = new SqlCommand(eliminar);
            SqlDataAdapter mostrar = new SqlDataAdapter(eliminar, conexion);
            DataTable movi = new DataTable();
            mostrar.Fill(movi);
            dgvRegistro.DataSource = movi;
            MessageBox.Show("Registro eliminado");
            dgvRegistro.DataSource = fn.Llenargrid("select * from Existencia");

            conexion.Close();
        
        }

        private void button6_Click(object sender, EventArgs e)
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
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dgvRegistro.Rows[e.RowIndex];

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

        private void btnVer_Click(object sender, EventArgs e)
        {
            dgvRegistro.DataSource = fn.Llenargrid("select * from Existencia");
        }
    }
}


//if (fn.Eliminar ("Existencia", "No_parte=" + textNum.Text))
//{
//    MessageBox.Show("Registro eliminado");
//    dgvRegistro.DataSource = fn.Llenargrid("select * from Existencia");
//}
//else
//{
//    MessageBox.Show("Error al eliminar");
//}
