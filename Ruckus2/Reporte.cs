using System;
using System.Windows.Forms;

namespace Ruckus2
{
    public partial class Reporte : Form
    {
        Funciones fn = new Funciones();

        public Reporte()
            
        {
            InitializeComponent();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            dgv_Registros.DataSource = fn.LlenarGrid("SELECT * FROM Movimientos WHERE Fecha BETWEEN '" + fechaI.Value.Date + "' AND '" + fechaF.Value.Date + "'");
        }
    } 
}

