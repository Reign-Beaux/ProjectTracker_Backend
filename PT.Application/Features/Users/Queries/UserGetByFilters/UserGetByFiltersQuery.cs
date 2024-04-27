using MediatR;
using PT.Application.Models.Responses;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;

namespace PT.Application.Features.Users.Queries.UserGetByFilters
{
    public class UserGetByFiltersQuery : UserGetByFiltersPayload, IRequest<IResponse>
    {
    }
}
