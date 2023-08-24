using POS.Application.Commons.Bases;
using POS.Application.Dtos.Category.Request;
using POS.Application.Dtos.Response;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDTO>>> ListCategories(BaseFiltersRequest filters);

        Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectCategories();

        Task<BaseResponse<CategoryResponseDTO>> CategoryById(int categoryId);

        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);

        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);

        Task<BaseResponse<bool>> RemoveCategory(int categoryId);

    }
}
