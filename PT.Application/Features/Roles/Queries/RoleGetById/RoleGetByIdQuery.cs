using MediatR;
using PT.Application.Services.ResponseManagement.Models;

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
