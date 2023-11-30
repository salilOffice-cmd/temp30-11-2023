using Application.DTOs.StudentDTOs;
using AutoMapper;
using Domain.Entities;

namespace WebApi.Mappings
{

    // In ASP.NET Core, AutoMapper is a widely used library that
    // simplifies the mapping between different types.
    // It's particularly helpful when you need to transform objects from one type to another,
    // often used in scenarios like mapping domain entities to DTOs or vice versa.

    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {

            // 1. Getting Student

            // Mapping source --> Destination
            CreateMap<Student, ViewStudentDTO>();

            // In case the name of the property are different in source and destination
            CreateMap<Student, ViewStudentDTO>()
                .ForMember(dest => dest.StudentName111,
                           opt => opt.MapFrom(src => src.StudentName))
            // In case you have some extra when showing the property
                .ForMember(dest => dest.CreatedDetails,
                           opt => opt.MapFrom(src => $"{src.CreatedBy} - {src.CreatedDate}"));



            // 2. Adding Student
            CreateMap<AddStudentDTO, Student>();

        }
    }
}
