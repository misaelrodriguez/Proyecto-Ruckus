using System;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;    

namespace Ruckus2
{
    public partial class Usuario : Form
    {
        Funciones fn = new Funciones();

        public Usuario()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = "SELECT Descripcion, Modelo, Categoria, Localidad, Cantidad, Usuario FROM Existencias WHERE No_parte = '" + textNo_part.Text + "'";

            ArrayList data = new ArrayList();

            data = fn.Buscar(query);

            if (data.Count > 0)
            {
                textDescripcion.Text = data[0].ToString();
                textModel.Text = data[1].ToString();
                textCatego.Text = data[2].ToString();
                textLocal.Text = data[3].ToString();
                textCanti.Text = data[4].ToString();
                textUser.Text = data[5].ToString();
                //MessageBox.Show("El componente esta en existencia");
            }
            else
            {
                MessageBox.Show("No se encuentra en existencia", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

                textDescripcion.Text = "";
                textModel.Text = "";
                textCatego.Text = "";
                textLocal.Text = "";
                textCanti.Text = "";
                textUser.Text = "";
            }
        }
        
        private void btnRequerir_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Movimientos (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, Usuario) VALUES ('" + textNo_part.Text + "', '" + textDescripcion.Text + "', '" + textModel.Text + "', '" + textCatego.Text + "', '" + textLocal.Text + "', '" + textCanti.Text +"', '" + textUser.Text + "' )";

            if (fn.Insertar(query))
            {
                MessageBox.Show("Requerimiento con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al requerir", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnDisponible_Click(object sender, EventArgs e)
        {
            string query = "SELECT Cantidad FROM Existencias WHERE No_parte = '" + textNo_part.Text + "'";

            ArrayList data = new ArrayList();

            data = fn.Buscar(query);

            if (data.Count > 0)
            {
                textDisponible.Text = data[0].ToString();
                //MessageBox.Show("El componente esta en existencia");
            }
            else
            {
                MessageBox.Show("No se encuentra en existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textDisponible.Text = "";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
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
    } 
}
