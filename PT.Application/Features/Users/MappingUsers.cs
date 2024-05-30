using AutoMapper;
using PT.Application.Features.Users.Commands.UserInsert;
using PT.Application.Features.Users.Commands.UserUpdate;
using PT.Application.Features.Users.Queries.UserGetByFilters;
using PT.Application.Features.Users.Queries.UserGetById;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;

namespace PT.Application.Features.Users
{
    public class MappingUsers : Profile
    {
        public MappingUsers()
        {
            CreateMap<UserInsertCommand, UserInsertPayload>();
            CreateMap<UserUpdateCommand, UserUpdatePayload>();
            CreateMap<User, UserGetByFiltersQueryResponse>();
            CreateMap<User, UserGetByIdQueryResponse>();
        }
    }
}
