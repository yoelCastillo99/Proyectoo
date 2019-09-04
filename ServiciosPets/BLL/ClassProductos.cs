using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using MODELS;
using System.Collections;

namespace BLL
{
   public class ClassProductos
    {
        public IEnumerable ListarProductos()
        {
            RepositorioGenerico<Productos> REP = new RepositorioGenerico<Productos>();
            return REP.ListarTodo();
        }

        public IEnumerable BuscaProductoNombre(string nombre)
        {
            RepositorioGenerico<Productos> REP = new RepositorioGenerico<Productos>();
            return REP.ListarTodoConFiltro(c => c.Nombre_Producto == nombre);


        }//Fin de BuscaProductoNombre

        public string NuevoProducto(float descuento, string nombreproducto, float preciosindescuento, string unidad, bool habilitar, int tipo)
        {
            RepositorioGenerico<Productos> REP = new RepositorioGenerico<Productos>();
            Productos PDT = new Productos();
            string resultado;
            try
            {
                IEnumerable busca = BuscaProductoNombre(nombreproducto);
                if (busca.Cast<object>().Any())
                    resultado = "Error: ya existe el cliente " + nombreproducto;
                else
                {
                    PDT.Productos_Id = Convert.ToInt32(REP.ListarTodo().Max(p => p.Productos_Id)) + 1;//los lista
                    PDT.Nombre_Producto = nombreproducto;
                    PDT.Descuento = descuento;
                    PDT.PreciosinDecuento = preciosindescuento;
                    PDT.Unidad_de_medida = unidad;
                    PDT.Habilitar = habilitar;
                    PDT.Tipo_Id = tipo;
                    resultado = REP.Agregar(PDT);
                }
            }
            catch (Exception error)
            {
                resultado = "Error " + error.Message;

            }
            return resultado;
        }//fin de NuevoProducto

        public string ActualizaProducto(Productos Info)
        {
            string resultado = "";
            RepositorioGenerico<Productos> REP = new RepositorioGenerico<Productos>();
            try
            {
                resultado = REP.Editar(Info);
            }
            catch (Exception error)
            {

                resultado = "Error " + error.Message;
            }
            return resultado;
        }//fin de ActualizaProducto

    }
}
