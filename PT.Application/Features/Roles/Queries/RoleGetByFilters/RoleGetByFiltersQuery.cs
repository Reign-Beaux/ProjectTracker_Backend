using MediatR;
using PT.Application.Models.DataGrid;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Roles.Queries.RoleGetByFilters
{
    public class RoleFilterModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class RoleGetByFiltersQuery : IRequest<IResponse>
    {
        public RoleFilterModel RolesFilter { get; set; }
        public PaginationModel Pagination { get; set; }
        public SortModel Sort { get; set; }
    }
}
