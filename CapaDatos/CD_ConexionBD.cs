using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    class CD_ConexionBD
    {
        private SqlConnection conexion = new SqlConnection("Server=DESKTOP-MK1G6S9\\SQLEXPRESS; DataBase = crud_Pratica; Integrated Security=true");

        //Abrir la conexion con la base de Datos
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();

            return conexion;
        }

        //Cerrar la conexion con la base de Datos
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();

            return conexion;
        }
    }
}
