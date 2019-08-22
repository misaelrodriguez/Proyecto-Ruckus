using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Windows.Forms;
namespace Ruckus2
{
    class Funciones
    {
        SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;  

        public bool Conectar()
        {
            bool conectado = false;

            try
            {
                conexion.Open();
                conectado = true;
            }
            catch (SqlException)
            {
                conectado = false;
            }
            finally
            {
                conexion.Close();
            }
            return conectado;
        }


        public bool Insertar(string consulta)
        {
            bool agregado = false;
            int rows = 0;

            conexion.Open();
            cmd = new SqlCommand(consulta, conexion);
            rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                agregado = true;
            }

            conexion.Close();

            return agregado;
        }
        public bool Actualizar(string consulta)
        {
            bool actualizado = false;
            int rows = 0;

            conexion.Open();
            cmd = new SqlCommand(consulta, conexion);
            rows = cmd.ExecuteNonQuery();

            if (rows > 0)
            {
                actualizado = true;
            }

            conexion.Close();

            return actualizado;
        }
        public bool Eliminar(string tabla, string condicion)
        {

            conexion.Open();
            string elimina =" delete  from " + tabla + "where" + condicion;
            cmd = new SqlCommand(elimina, conexion);
            int i = cmd.ExecuteNonQuery();
            conexion.Close();
            if (i > 0)
            {
                return true;
            }

            else
            {
                return false;
            }


        }
        public DataTable Llenargrid(string consulta)
        {
            conexion.Open();
            cmd = new SqlCommand(consulta, conexion);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();

            da.Fill(dt);
            conexion.Close();

            return dt;
        }

        public DataTable Mostrar(string consulta)
        {
            conexion.Open();
            cmd = new SqlCommand(consulta, conexion);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();

            da.Fill(dt);
            conexion.Close();

            return dt;
        }
    }
}

    

