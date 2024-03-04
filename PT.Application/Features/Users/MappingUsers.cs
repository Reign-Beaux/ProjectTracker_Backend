using AutoMapper;
using PT.Application.Features.Users.Commands.UserInsert;
using PT.Application.Features.Users.Commands.UserUpdate;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;

namespace PT.Application.Features.Users
{
    public class MappingUsers : Profile
    {
        public MappingUsers()
        {
            CreateMap<UserInsertCommand, UserInsertParameters>();
            CreateMap<UserUpdateCommand, UserUpdateParameters>();
        }
    }
}
