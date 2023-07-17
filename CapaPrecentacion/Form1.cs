using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPrecentacion
{
    public partial class Form1 : Form
    {

        CN_Productos objectoCN = new CN_Productos();
        private string idProducto = null;
        private bool editar = false;
        public Form1()
        {
            InitializeComponent();
        
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);
        //-----------------------------------------------------------------------------------------------------------------------------------
        
        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProducto();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objectoCN.InsertarPro(
                        txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se Agrego correcta Mente!!");
                    MostrarProducto();
                    LimpiarForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO Se puedo agregar los datos Por" + ex);
                }
            }
            if (editar == true)
            {
                try
                {
                    objectoCN.EditarPro(
                        txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se Edito correcta Mente!!");
                    MostrarProducto();
                    LimpiarForm();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NO Se Edictar los datos Por" + ex);
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione un elemento");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objectoCN.EliminarPro(idProducto);
                MessageBox.Show("Se a eliminado Correcta mente!!");
                MostrarProducto();
            }
            else
            {
                MessageBox.Show("Selecione un elemento!!");
            }
        }

        public void MostrarProducto()
        {
            CN_Productos objecto = new CN_Productos();
            dataGridView1.DataSource = objecto.MostrarProd();
        }
        public void LimpiarForm()
        {
            txtNombre.Clear();
            txtDesc.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Focus();
        }


        //==============================================Mover y Cerrar la Applicacion------------------------------------------
        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //--------------------------------------------------------------------------------------------------------------------
    }
}
