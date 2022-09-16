using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud;
using AccesoDatosProductos;
using EntidadesTienda;
using System.Windows.Forms;
using System.Drawing;

namespace ManejadorProductos
{
    public class ManejadorP
    {
        AccesoaProductos ap = new AccesoaProductos();
        Grafico g = new Grafico();
        public void Guardar(Productos Entidad)
        {
            ap.Guardar(Entidad);
            g.MensajeAlerta("Se han guardado los cambios", "!Atención", MessageBoxIcon.Information);
        }
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.RowTemplate.Height = 30;
            tabla.DataSource = ap.Mostrar(filtro).Tables["productos"];
            tabla.Columns.Insert(4, g.Boton("Editar", Color.Green));
            tabla.Columns.Insert(5, g.Boton("Borrar", Color.Red));
            tabla.Columns[0].Visible = false;
        }
        public void Borrar(Productos Entidad)
        {
            DialogResult rs = MessageBox.Show(string.Format(
            string.Format("Esta seguro de Borrar? :{0}", Entidad.Nombre)), "Atención",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                ap.Borrar(Entidad);
            }

        }
    }
}
