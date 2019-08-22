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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
            conexion.Open();

            String query = "select  Tipo_user from usuarios where Id_user = '" + textUser.Text + "' and Contraseña = '" + textPass.Text + "' ";
            SqlCommand cmd = new SqlCommand(query);
            SqlDataAdapter returnval = new SqlDataAdapter(query, conexion);
            DataTable dt = new DataTable();
            returnval.Fill(dt);
            conexion.Close();




            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "admin")
                {
                    MessageBox.Show("Bienvenido ingreso con perfil de Administrador");
                    Administrador llamar = new Administrador();
                    llamar.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Bienvenido Ingreso con el perfil de Usuario");
                    Usuario llamar = new Usuario();
                    llamar.Show();
                    this.Hide();

                }

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto");
            }



        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro re = new Registro();
            re.Show();
        }
    }
}

 