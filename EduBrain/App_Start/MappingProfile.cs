using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EduBrain.Models;
using EduBrain.ViewModels;

namespace EduBrain.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Student, StudentVm>();
            Mapper.CreateMap<Locker, LockerVm>();


            Mapper.CreateMap<StudentVm, Student>()
            .ForMember(c => c.StudentId, opt => opt.Ignore());
            Mapper.CreateMap<LockerVm, Locker>()
            .ForMember(c => c.StudentId, opt => opt.Ignore());
        }
    }
}