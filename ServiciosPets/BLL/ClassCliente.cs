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
    public class ClassCliente
    {
        public IEnumerable ListarClientes()
        {
            RepositorioGenerico<Clientes> REP = new RepositorioGenerico<Clientes>();
            return REP.ListarTodo();
        }

        public IEnumerable BuscaClienteNITyNombre(string nit, string nombre)
        {
            RepositorioGenerico<Clientes> REP = new RepositorioGenerico<Clientes>();
            return REP.ListarTodoConFiltro(c => c.NIT==nit ||c.Nombre==nombre);


        }//Fin de BuscaClienteNITyNombre

        public string NuevoCliente(string nit, string nombre, string apellido, string direccion, string telefono)
        {
            RepositorioGenerico<Clientes> REP = new RepositorioGenerico<Clientes>();
            Clientes CLI = new Clientes();
            string resultado;
            try
            {
                IEnumerable busca = BuscaClienteNITyNombre(nit, nombre);
                if (busca.Cast<object>().Any())
                    resultado = "Error: ya existe el cliente " + nombre;
                else
                {
                    CLI.Cliente_Id = Convert.ToInt32(REP.ListarTodo().Max(z => z.Cliente_Id)) + 1;//los lista
                    CLI.NIT = nit;
                    CLI.Nombre = nombre;
                    CLI.Apellido = apellido;
                    CLI.Direccion = direccion;
                    CLI.Telefono = telefono;
                    resultado = REP.Agregar(CLI);
                }
            }
            catch (Exception error)
            {
                resultado = "Error " + error.Message;
                
            }
            return resultado;
        }//fin de NuevoCliente

        public string ActualizaCliente(Clientes Info)
        {
            string resultado = "";
            RepositorioGenerico<Clientes> REP = new RepositorioGenerico<Clientes>();
            try
            {
                resultado = REP.Editar(Info);
            }
            catch (Exception error)
            {

                resultado = "Error " + error.Message;
            }
            return resultado;
        }//fin de ActualizaCliente
    }
}
