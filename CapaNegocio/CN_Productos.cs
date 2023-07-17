using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objectoCD = new CD_Productos();

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objectoCD.Mostrar();
            return tabla;
        }

        public void InsertarPro(string nombre, string des, string marcar, string precio, string stock)
        {
            objectoCD.Insertar(nombre, des, marcar, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        public void EditarPro(string nombre, string des, string marcar, string precio, string stock, string id)
        {
            objectoCD.Edictar(nombre, des, marcar, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        public void EliminarPro(string id)
        {
            objectoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
