using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_ConexionBD conexion = new CD_ConexionBD();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand command = new SqlCommand();

        public DataTable Mostrar()
        {
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "MostrarProductos";
            command.CommandType = CommandType.StoredProcedure;
            leer = command.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string desc, string marca, double precio, int stock)
        {
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "InsetarProductos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@descrip", desc);
            command.Parameters.AddWithValue("@Marca", marca);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@stock", stock);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Edictar(string nombre, string des, string marca, double precio, int stock, int id)
        {
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "EditarProductos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", nombre);
            command.Parameters.AddWithValue("@descrip", des);
            command.Parameters.AddWithValue("@Marca", marca);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@stock", precio);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Eliminar(int id)
        {
            command.Connection = conexion.AbrirConexion();
            command.CommandText = "EliminarProducto";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idpro", id);

            command.ExecuteNonQuery();

            command.Parameters.Clear();

            conexion.CerrarConexion();
        }
    }
}
