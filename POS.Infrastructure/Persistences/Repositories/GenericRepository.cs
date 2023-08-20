using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Helpers;
using POS.Infrastructure.Persistences.Interfaces;
using System.Linq.Dynamic.Core;

namespace POS.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //como no hay un contrato o no estamos cumpliendo la interfaz puesto que no hay ninguna interfaz lo ponemos como protected
        protected IQueryable<TDTO> Ordering<TDTO>   
            (BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDTO = request.Orden == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");
            if (pagination) queryDTO = queryDTO.Paginate(request);
            return queryDTO;
        }
    
    }
}
