using AutoMapper;
using Books.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Models.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorLogicModel>();
            CreateMap<AuthorLogicModel, Author>();
        }
    }
}
