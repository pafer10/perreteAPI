using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerreteAPI.Application.Infrastructure.UnitOfWork
{
    //se utiliza para guardar los cambios de los métodos = commit para hacerlo transaccional
    //para generar transacciones
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
