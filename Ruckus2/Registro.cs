using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruckus2
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
        Funciones fn = new Funciones();
        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            validarcampos();

            string agregar = "insert into usuarios values ('" + textId.Text + "', '" + textNombre.Text + "', '" + textContraseña.Text + "', '" + comboTipo.Text +"')";
            if (fn.Insertar(agregar))

               

            {
                MessageBox.Show("Cuenta creada con exito");
            }
            else
            {
                MessageBox.Show("Error al crear cuenta");
            }


        }

        private bool validarcampos()
        {
            bool ok = true;
            if (textId.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textId, "Ingresa ID de usurio");
            }

            if (textNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textNombre, "Ingresa nombre");
            }
            if (textContraseña.Text == "")
            {
                ok = false;
                errorProvider1.SetError(textContraseña, "Ingresa Contraseña");
            }
            if (comboTipo.Text == "")
            {
                ok = false;
                errorProvider1.SetError(comboTipo, "Selecciona el tipo de usuario");
            }

            return ok;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textId.Clear();
            textNombre.Clear();
            textContraseña.Clear();
        
        }
    }

}
