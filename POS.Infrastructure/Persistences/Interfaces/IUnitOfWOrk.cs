using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWOrk : IDisposable //es un mecanismo para liberar obejtos en memoria
    {
        //DECLARACION O MATRICULA DE NUESTRAS INTERFACES A NIVEL DE REPOSITORIO
        ICategoryRepository Category { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
