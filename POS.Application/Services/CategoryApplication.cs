using AutoMapper;
using POS.Application.Commons.Bases;
using POS.Application.Dtos.Category.Request;
using POS.Application.Dtos.Response;
using POS.Application.Interfaces;
using POS.Application.Validators.Category;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Request;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Infrastructure.Persistences.Interfaces;
using POS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IUnitOfWOrk _unitOfWOrk;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _validationRules;

        public CategoryApplication
            (IUnitOfWOrk unitOfWOrk, IMapper mapper, CategoryValidator validationRules)
        {
            _unitOfWOrk = unitOfWOrk;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<BaseEntityResponse<CategoryResponseDTO>>> ListCategories(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CategoryResponseDTO>>();
            var categories =  await _unitOfWOrk.Category.ListCategories(filters);
            if(categories is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<CategoryResponseDTO>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectCategories()
        {
            var response = new BaseResponse<IEnumerable<CategorySelectResponseDTO>>();
            var categories = await _unitOfWOrk.Category.GetAllAsync();
            if(categories is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<CategorySelectResponseDTO>>(categories);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
           
        }
        public async Task<BaseResponse<CategoryResponseDTO>> CategoryById(int categoryId)
        {
            var response = new BaseResponse<CategoryResponseDTO>();
            var category = await _unitOfWOrk.Category.GetByIdAsync(categoryId);
            if(category is not null) { 
                response.IsSuccess = true;
                response.Data = _mapper.Map<CategoryResponseDTO>(category);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;    
        }


        public async Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(requestDto);
            if(!validationResult.IsValid)
            {
                response.IsSuccess = false; 
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            var category = _mapper.Map<Category>(requestDto);
            response.Data = await _unitOfWOrk.Category.RegisterAsync(category);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;    

        }
        public async Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await CategoryById(categoryId);
            if(categoryEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            var category = _mapper.Map<Category>(requestDto);
            category.Id = categoryId;
            response.Data = await _unitOfWOrk.Category.EditAsync(category);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

       
        public async Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            var response = new BaseResponse<bool>();
            var category = await CategoryById(categoryId);

            if(category.Data is null) {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitOfWOrk.Category.RemoveAsync(categoryId);
            if(response.Data)
            {
                response.Data = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message += ReplyMessage.MESSAGE_FAILED;    
            }

            return response;
        }
    }
}
