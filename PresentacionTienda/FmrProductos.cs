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
using AccesoDatosProductos;


namespace PresentacionTienda
{
    public partial class FmrProductos : Form
    {
        ManejadorP P;
        public static Productos entidad = new Productos(0, "", "", "");
        int fila = 0, col = 0;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            entidad.Id = -1;
            FmrAñadirProductos ap = new FmrAñadirProductos();
            ap.ShowDialog();
            Actualizar();
        }
        void Actualizar()
        {
            P.Mostrar(dgtProducto, txtBuscar.Text);
        }

        private void dgtProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            entidad.Id = int.Parse(dgtProducto.Rows[fila].Cells[0].Value.ToString());
            entidad.Nombre = dgtProducto.Rows[fila].Cells[1].Value.ToString();
            entidad.Descripcion = dgtProducto.Rows[fila].Cells[2].Value.ToString();
            entidad.Precio = dgtProducto.Rows[fila].Cells[3].Value.ToString();
            switch (col)
            {
                case 4:
                    {
                        FmrAñadirProductos fad = new FmrAñadirProductos();
                        fad.ShowDialog();
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
                case 5:
                    {
                        P.Borrar(entidad);
                        txtBuscar.Text = "";
                        Actualizar();
                    }
                    break;
            }
        }

        private void dgtProducto_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            col = e.ColumnIndex;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void FmrProductos_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public FmrProductos()
        {
            InitializeComponent();
            P = new ManejadorP();
        }
    }
}
