using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface ICategoryRepository  : IGenericRepository<Category>//PATRON UNITOF WORK ESTA INTERFZ DEBE DE SER DECLARADA EN EL UNITOFWORK
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);
        
    }
}
