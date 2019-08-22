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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Existencia es = new Existencia();
            es.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Movimientos mo = new Movimientos();
            mo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reporte re = new Reporte();
            re.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListaUsaurios lis = new ListaUsaurios();
            lis.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
