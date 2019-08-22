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
    public partial class Reporte : Form
    {
        public Reporte()
            
        {
            InitializeComponent();
        }

        //SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
      
        //public Reporte(DataGridView tabla, DateTime fechaI, DateTime fechaF)
        //{
        //    SqlDataAdapter ad = new SqlDataAdapter(" select * from Movimientos where Fecha between  '"+ fechaI + "' and '" + fechaF + "'", conexion);
        //    DataSet dataS = new DataSet();
        //    ad.Fill(dataS, "Movimientos");
        //   tabla.DataSource = dataS.Tables ("Movimientos");
        //}
    } 
}

