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
    public partial class Movimientos : Form
    {
        public Movimientos()
        {
            InitializeComponent();
        }
        Funciones fn = new Funciones();

        private void Movimientos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fn.Llenargrid("select * from Movimientos");
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
            conexion.Open();
            string buscar = "Select * from Movimientos Where Id_mov = '" + textIdmov.Text + "' ";
            SqlCommand cmd = new SqlCommand(buscar);
            SqlDataAdapter mostrar = new SqlDataAdapter(buscar, conexion);
            DataTable movi = new DataTable();
            mostrar.Fill(movi);
            dataGridView1.DataSource = movi;
            conexion.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
            conexion.Open();
            string eliminar = "Delete from Movimientos Where Id_mov = '" + textIdmov.Text + "' ";
            SqlCommand cmd = new SqlCommand(eliminar);
            SqlDataAdapter mostrar = new SqlDataAdapter(eliminar, conexion);
            DataTable movi = new DataTable();
            mostrar.Fill(movi);
            dataGridView1.DataSource = movi;
            MessageBox.Show("Registro eliminado");
            dataGridView1.DataSource = fn.Llenargrid("select * from Movimientos");

            conexion.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textIdmov.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fn.Llenargrid("select * from Movimientos");
        }
    }
}
