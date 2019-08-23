using System;
using System.Windows.Forms;

namespace Ruckus2
{
    public partial class Registro : Form
    {
        Funciones fn = new Funciones();

        public Registro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(ValidarCampos())
            { 
                string query = "INSERT INTO Usuarios VALUES('" + textId.Text + "', '" + textNombre.Text + "', '" + textContraseña.Text + "', '" + comboTipo.Text +"')";

                if (fn.Insertar(query))
                {
                    MessageBox.Show("Cuenta creada con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear cuenta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textId.Clear();
            textNombre.Clear();
            textContraseña.Clear();
            comboTipo.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            bool validado = true;

            if (textId.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textId, "Ingresa ID de usurio");
            }

            if (textNombre.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textNombre, "Ingresa nombre");
            }
            if (textContraseña.Text == "")
            {
                validado = false;
                errorProvider1.SetError(textContraseña, "Ingresa Contraseña");
            }
            if (comboTipo.Text == "")
            {
                validado = false;
                errorProvider1.SetError(comboTipo, "Selecciona el tipo de usuario");
            }

            return validado;
        }
    }

}
