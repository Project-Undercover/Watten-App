﻿using AutoMapper;
using Infrastructure.DTOs.Users;
using Infrastructure.Entities.Sessions;
using Infrastructure.Entities.Users;

namespace Services.Users
{
    public class UserServiceMapper : Profile
    {
        public UserServiceMapper()
        {
            CreateMappers();
        }


        public void CreateMappers()
        {
            CreateMap<UserDTOs.Requests.Create, User>()
                .ForMember(s => s.Children, opt => opt.MapFrom(s => s.Children.Select(s => new Child { Name = s }).ToList()));
            CreateMap<UserDTOs.Requests.Edit.Child, Child>();
            CreateMap<UserDTOs.Requests.Edit, User>();


            CreateMap<UserDTOs.Requests.AddChild, Child>();


            CreateMap<User, UserDTOs.Responses.GetAllDT>()
                .ForMember(s => s.roleName, opt => opt.MapFrom(s => s.Role));
            CreateMap<User, UserDTOs.Responses.GetById>();
            CreateMap<Child, UserDTOs.Responses.GetById.Child>();

            CreateMap<Child, UserDTOs.Responses.Child>();


            CreateMap<Session, UserDTOs.Responses.HomeData.Session>()
                .ForMember(s => s.children, opt => opt.MapFrom(s => s.Participants.Select(s => new UserDTOs.Responses.HomeData.Session.Child { id = s.ChildId, name = s.Child.Name }).ToList()))
                .ForMember(s => s.instructors, opt => opt.MapFrom(s => s.Instructors.Select(s => s.User.FirstName + " " + s.User.LastName).ToList()));


        }
    }
}
