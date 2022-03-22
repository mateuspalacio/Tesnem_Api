using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Professor, ProfessorDto>().ReverseMap();
        }
    }
}
