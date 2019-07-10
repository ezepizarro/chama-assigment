using AutoMapper;
using Chama.Core.Entities;
using Chama.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chama.Core.Mappings
{
    public class SimpleMappings : Profile
    {
        public SimpleMappings()
        {
            //Student

            CreateMap<Student, CreateStudentModel>();
            CreateMap<CreateStudentModel, Student>();
            CreateMap<Student, StudentModel>();
            CreateMap<StudentSession, StudentSessionModel>();

            //Course

            //Session
            CreateMap<Session, SessionListModel>()
                .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Course.Name));

            CreateMap<Session, SessionDetailModel>()
                .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Course.Name));
            
            //Teacher
            CreateMap<Teacher, TeacherModel>();
        }
    }
}
