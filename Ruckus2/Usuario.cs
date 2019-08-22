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
    public partial class Usuario : Form
    {
        SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cadsql = "select Descripcion, Modelo, Categoria, Localidad From Existencia Where No_parte = '" + textNo_part.Text + "'";
            SqlCommand comando = new SqlCommand(cadsql, conexion);
            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                textDescripcion.Text = leer["Descripcion"].ToString();
                textModel.Text = leer["Modelo"].ToString();
                textCatego.Text = leer["Categoria"].ToString();
                textLocal.Text = leer["Localidad"].ToString();
                //MessageBox.Show("El componente esta en existencia");
            }
            else
            {
                MessageBox.Show("No se encuentra en existencia");

                textDescripcion.Text = "";
                textModel.Text = "";
                textCatego.Text = "";
                textLocal.Text = "";
               
            }
            conexion.Close();
        }
        Funciones fn = new Funciones();
        private void btninsertar_Click(object sender, EventArgs e)
        {
            string agregar = "insert into Movimientos (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, Usuario) values ('" + textNo_part.Text + "', '" + textDescripcion.Text + "', '" + textModel.Text + "', '" + textCatego.Text + "', '" + textLocal.Text + "', '" + textCanti.Text +"', '" + textUser.Text + "' )";
            if (fn.Insertar(agregar))


            {
                MessageBox.Show("Requerimiento con exito");
            }
            else
            {
                MessageBox.Show("Error al requerir");
            }

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            textNo_part.Clear();
            textDescripcion.Clear();
            textModel.Clear();
            textCatego.Clear();
            textLocal.Clear();
            textCanti.Clear();
            textUser.Clear();
            textDisponible.Clear();
        }

        private void btndisponible_Click(object sender, EventArgs e)
        {
            
         SqlCommand comando = new SqlCommand("select cantidad From Existencia Where No_parte = '" + textNo_part.Text + "'", conexion);
            comando.Parameters.AddWithValue("No_parte", textNo_part.Text);
            conexion.Open();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                textDisponible.Text = registro["Cantidad"].ToString();
            }
            conexion.Close();
        }
    } 
}
