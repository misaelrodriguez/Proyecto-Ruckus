using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace Ruckus2
{
    class Funciones
    {
        //SqlConnection conexion = new SqlConnection("server=LAPTOP-48CP0M82\\MSSQLSERVER1 ; database=Inventario ; integrated security = true");
        SqlConnection conexion = new SqlConnection("SERVER=DESKTOP-KSNIIKV\\SQLEXPRESS; DATABASE=Inventario; INTEGRATED SECURITY = true");

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

            string elimina =" DELETE FROM " + tabla + " WHERE " + condicion;

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

        public DataTable LlenarGrid(string consulta)
        {
            conexion.Open();

            cmd = new SqlCommand(consulta, conexion);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();

            da.Fill(dt);
            conexion.Close();

            return dt;
        }

        public ArrayList Buscar(string consulta)
        {
            ArrayList result = new ArrayList();

            conexion.Open();

            cmd = new SqlCommand(consulta, conexion);

            SqlDataReader info = cmd.ExecuteReader();

            while (info.Read())
            {
                for (int i = 0; i < info.FieldCount; i++)
                {
                    result.Add(Convert.ToString(info.GetValue(i)));
                }
            }

            conexion.Close();

            return result;
        }
    }
}

    

