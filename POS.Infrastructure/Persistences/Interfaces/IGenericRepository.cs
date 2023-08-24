using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : /*class*/ BaseEntity
    {
         Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<bool> RegisterAsync(T entity);

        Task<bool> EditAsync(T entity); 

        Task<bool> RemoveAsync(int id);

        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null); //deuvel un queryable en base  auna entoidad que le estemos apsando

        IQueryable<TDTO> Ordering<TDTO>
            (BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class;
    } 
}
