using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConectarBd;
using EntidadesTienda;

namespace AccesoDatosProductos
{
    public class AccesoaProductos
    {
        Base b = new Base("localhost", "root", "", "Tienda", 3306);

        public void Guardar(Productos Entidad)
        {
            b.Comando(string.Format("Call insertproducto({0},'{1}','{2}','{3}')",
                Entidad.Id, Entidad.Nombre, Entidad.Descripcion, Entidad.Precio));
        }
        public DataSet Mostrar(string filtro)
        {
            return b.Obtener
                (string.Format("Call showproductos('%{0}%')", filtro), "Productos");
        }
        public void Borrar(Productos id)
        {
            b.Comando(string.Format("delete from productos where id = {0}", id.Id));
        }
    }
}
