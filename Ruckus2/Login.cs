using System;
using System.Collections;
using System.Windows.Forms;

namespace Ruckus2
{
    public partial class Login : Form
    {
        Funciones fn = new Funciones();

        public Login()
        {
            InitializeComponent();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            String query = "SELECT Tipo_user FROM Usuarios WHERE Id_user = '" + textUser.Text + "' AND Contrasena = '" + textPass.Text + "' ";

            ArrayList data = new ArrayList();

            data = fn.Buscar(query);

            if (data.Count > 0)
            {
                MessageBox.Show("Bienvenido Ingreso con Perfil de Administrador", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Administrador llamar = new Administrador();
                llamar.Show();
                this.Hide();
            }
            else
            {
                textUser.Text = "";
                textPass.Text = "";

                MessageBox.Show("Usuario o Contraseña Incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro re = new Registro();
            re.ShowDialog();
        }
    }
}

 