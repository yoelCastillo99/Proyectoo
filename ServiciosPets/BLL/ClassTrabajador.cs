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
    public class ClassTrabajador
    {
        public IEnumerable ListarProductos()
        {
            RepositorioGenerico<Trabajador> REP = new RepositorioGenerico<Trabajador>();
            return REP.ListarTodo();
        }

        public IEnumerable BuscaTrabajadorporDPIyNombre(string dpi, string nombre)
        {
            RepositorioGenerico<Trabajador> REP = new RepositorioGenerico<Trabajador>();
            return REP.ListarTodoConFiltro(t => t.DPI == dpi || t.Nombre == nombre);


        }//Fin de BuscaTrabajadorporDPIyNombre

        public string NuevoTrabajador(string dpi, string nombre, string apellido, string direccion, string telefono, string usuario, string password, bool habilitar, int tipoEmpleadoid)
        {
            RepositorioGenerico<Trabajador> REP = new RepositorioGenerico<Trabajador>();
            Trabajador TBR = new Trabajador();
            string resultado;
            try
            {
                IEnumerable busca = BuscaTrabajadorporDPIyNombre(dpi, nombre);
                if (busca.Cast<object>().Any())
                    resultado = "Error: ya existe el cliente " + nombre;
                else
                {
                    TBR.Empleado_Id = Convert.ToInt32(REP.ListarTodo().Max(z => z.Empleado_Id)) + 1;//los lista
                    TBR.DPI = dpi;
                    TBR.Nombre = nombre;
                    TBR.Apellido = apellido;
                    TBR.Direccion = direccion;
                    TBR.Telefono = telefono;
                    TBR.Password = password;
                    TBR.Usuario = usuario;
                    TBR.Habilitar = habilitar;
                    TBR.TipoEmpleado_Id = tipoEmpleadoid;
                    resultado = REP.Agregar(TBR);
                }
            }
            catch (Exception error)
            {
                resultado = "Error " + error.Message;

            }
            return resultado;
        }//fin de NuevoTrabajador

        public string ActualizaTrabajador(Trabajador Info)
        {
            string resultado = "";
            RepositorioGenerico<Trabajador> REP = new RepositorioGenerico<Trabajador>();
            try
            {
                resultado = REP.Editar(Info);
            }
            catch (Exception error)
            {

                resultado = "Error " + error.Message;
            }
            return resultado;
        }//fin de ActualizaTrabajador
    }
}
