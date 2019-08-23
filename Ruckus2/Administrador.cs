using System;
using System.Windows.Forms;

namespace Ruckus2
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void btnExistencias_Click(object sender, EventArgs e)
        {
            Existencia ex = new Existencia();
            ex.ShowDialog();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            Movimientos mo = new Movimientos();
            mo.ShowDialog();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte re = new Reporte();
            re.ShowDialog();
        }

        private void btnListaUsuarios_Click(object sender, EventArgs e)
        {
            ListaUsaurios lis = new ListaUsaurios();
            lis.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
