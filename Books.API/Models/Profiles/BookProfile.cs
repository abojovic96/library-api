using AutoMapper;
using Books.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookLogicModel, BookDetailDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.GenreName))
                .ReverseMap();

            CreateMap<BookLogicModel, BookDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.GenreName));
        }
    }
}
