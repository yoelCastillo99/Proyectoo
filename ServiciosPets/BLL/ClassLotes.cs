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
    public class ClassLotes
    {
        public IEnumerable ListarLotes()
        {
            RepositorioGenerico<Lotes> REP = new RepositorioGenerico<Lotes>();
            return REP.ListarTodo();
        }

        public IEnumerable BuscaLoteNombre(string nombre)
        {
            RepositorioGenerico<Lotes> REP = new RepositorioGenerico<Lotes>();
            return REP.ListarTodoConFiltro(c => c.Descripcion == nombre);


        }//Fin de BuscaLoteNombre

        public string NuevaDescripcion(string descripcion, int cantidad, string fechacaducidad, string fechaproduccion, int tipo)
        {
            RepositorioGenerico<Lotes> REP = new RepositorioGenerico<Lotes>();
            Lotes LTS = new Lotes();
            string resultado;
            try
            {
                IEnumerable busca = BuscaLoteNombre(descripcion);
                if (busca.Cast<object>().Any())
                    resultado = "Error: ya existe el cliente " + descripcion;
                else
                {
                    LTS.Id_Lotes = Convert.ToInt32(REP.ListarTodo().Max(l => l.Id_Lotes)) + 1;//los lista
                    LTS.Descripcion = descripcion;
                    LTS.Cantidad = cantidad;
                    LTS.Fecha_Caducidad = Convert.ToDateTime(fechacaducidad);
                    LTS.Fecha_Produccion = Convert.ToDateTime(fechaproduccion);
                    LTS.Productos_Id = tipo;
                    resultado = REP.Agregar(LTS);
                }
            }
            catch (Exception error)
            {
                resultado = "Error " + error.Message;

            }
            return resultado;
        }//fin de NuevoLote

        public string ActualizaLotes(Lotes Info)
        {
            string resultado = "";
            RepositorioGenerico<Lotes> REP = new RepositorioGenerico<Lotes>();
            try
            {
                resultado = REP.Editar(Info);
            }
            catch (Exception error)
            {

                resultado = "Error " + error.Message;
            }
            return resultado;
        }//fin de ActualizaLotes

    }
}
