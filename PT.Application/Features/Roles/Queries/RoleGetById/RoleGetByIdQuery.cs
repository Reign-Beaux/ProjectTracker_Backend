using MediatR;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Roles.Queries.RoleGetById
{
    public class RoleGetByIdQuery : IRequest<IResponse>
    {
        public int Id { get; set; }

        public RoleGetByIdQuery(int? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
