using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesnem.Api.Domain.Auth;
using Tesnem.Api.Domain.DTO;
using Tesnem.Api.Domain.DTO.RequestDTO;
using Tesnem.Api.Domain.DTO.ResponseDTO;
using Tesnem.Api.Domain.Models;

namespace Tesnem.Api.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Request mapping
            CreateMap<Enrollment, EnrollmentRequest>().ReverseMap();
            CreateMap<List<Guid>, AddClassesRequest>().ReverseMap();
            CreateMap<Student, StudentRequest>().ReverseMap();
            CreateMap<Professor, ProfessorRequest>().ReverseMap();
            CreateMap<PersonalData, PersonalDataRequest>().ReverseMap();
            CreateMap<Person, PersonRequest>().ReverseMap();
            CreateMap<ProgramMajor, MajorRequest>().ReverseMap();
            // Response mapping
            CreateMap<Enrollment, EnrollmentResponse>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Professor, ProfessorResponse>().ReverseMap();
            CreateMap<PersonalData, PersonalDataResponse>().ReverseMap();
            CreateMap<Person, PersonResponse>().ReverseMap();
            CreateMap<ProgramMajor, MajorResponse>().ReverseMap();

            // registration
            CreateMap<UserRegistration, User>().ReverseMap();
        }
    }
}
