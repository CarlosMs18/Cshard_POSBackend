using AutoMapper;
using POS.Application.Dtos.Category.Request;
using POS.Application.Dtos.Response;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile()
        {
            CreateMap<Category, CategoryResponseDTO>()
                 .ForMember(x => x.CategoryId, x =>  x.MapFrom(y => y.Id))
                 .ForMember
                 (x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                 .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDTO>>()
                .ReverseMap();

            CreateMap<CategoryRequestDto, Category>();
            CreateMap<Category, CategorySelectResponseDTO>()
                .ForMember(x => x.CategoryId, X=> X.MapFrom(y => y.Id)) 
                .ReverseMap();
        }
    }
}
