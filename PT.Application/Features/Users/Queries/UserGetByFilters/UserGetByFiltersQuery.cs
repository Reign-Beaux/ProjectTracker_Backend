using MediatR;
using PT.Application.Models.DataGrid;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Users.Queries.UserGetByFilters
{
    public class UsersFilterModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PaternalLastName { get; set; }
        public string MaternalLastname { get; set; }
        public string Email { get; set; }
    }

    public class UserGetByFiltersQuery : IRequest<IResponse>
    {
        public UsersFilterModel UsersFilter { get; set; }
        public PaginationModel Pagination { get; set; }
        public SortModel Sort { get; set; }
    }
}
