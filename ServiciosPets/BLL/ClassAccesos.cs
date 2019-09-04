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
    public class ClassAccesos
    {
        public IEnumerable BuscarAccesoPorNombre(string nombre)
        {
            RepositorioGenerico<Accesos> REP = new RepositorioGenerico<Accesos>();
            var respuesta = REP.ListarTodoConFiltro(b => b.Descripcion == nombre);
            return respuesta;
        }//fin de BuscarAccesoPorNombre

        public IEnumerable MostrarTodo()
        {
            RepositorioGenerico<Accesos> Rep = new RepositorioGenerico<Accesos>();
            var resutado = Rep.ListarTodo();
            return resutado;

        }

        public string NuevoAcceso(string descripcion, bool ventas, bool productos, bool reportes)
        {
            RepositorioGenerico<Accesos> REP = new RepositorioGenerico<Accesos>();
            Accesos NUEVO = new Accesos();
            string resultado = "";
            try
            {
                IEnumerable busca = BuscarAccesoPorNombre(descripcion);
                if (busca.Cast<object>().Any())
                    resultado = "Error: ya existe el estado " + descripcion;
                else
                {
                    NUEVO.Accesos_Id = Convert.ToInt32(REP.ListarTodo().Max(z => z.Accesos_Id)) + 1;//los lista
                    NUEVO.Descripcion = descripcion;
                    NUEVO.Ventas = ventas;
                    NUEVO.Productos = productos;
                    NUEVO.Reportes = reportes;
                    resultado = REP.Agregar(NUEVO);
                }
            }
            catch (Exception error)
            {

                resultado = "ERROR" + error.Message;
            }
            return resultado;
                
        }//fin del NuevoAcceso

        public string ActualizaAcceso(Accesos Info)
        {
            string resultado = "";
            RepositorioGenerico<Accesos> REP = new RepositorioGenerico<Accesos>();
            try
            {
                resultado = REP.Editar(Info);
            }
            catch (Exception error)
            {

                resultado = "Error " + error.Message;
            }
            return resultado;
        }//fin de ActualizaAcceso

    }
}
