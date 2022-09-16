using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesTienda;
using ManejadorProductos;

namespace PresentacionTienda
{
    public partial class FmrAñadirProductos : Form
    {
        ManejadorP P;
        public FmrAñadirProductos()
        {
            InitializeComponent();
            P = new ManejadorP();
            if (FmrProductos.entidad.Id>0)
            {
                txtNombre.Text = FmrProductos.entidad.Nombre;
                txtdescripcion.Text = FmrProductos.entidad.Descripcion;
                txtPrecio.Text = FmrProductos.entidad.Precio;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecio.TextLength !=2)
                {
                    MessageBox.Show("Escribe bien");
                }
                else
                {
                    P.Guardar(new Productos(FmrProductos.entidad.Id,
                        txtNombre.Text,
                        txtdescripcion.Text,
                        txtPrecio.Text));
                    Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Todo bien");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
