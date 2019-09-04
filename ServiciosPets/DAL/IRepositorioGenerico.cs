using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace DAL
{
    public interface IRepositorioGenerico<T> where T : class
    {
        IQueryable<T> ListarTodo();
        string Agregar(T NuevaEntidad);
        string Editar(T Entidad);

        IQueryable<T> ListarTodoConFiltro(Expression<Func<T, bool>> filtro);

    }
}
