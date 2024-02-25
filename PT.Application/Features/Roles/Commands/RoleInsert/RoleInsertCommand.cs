using MediatR;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Roles.Commands.RoleInsert
{
    public class RoleInsertCommand : IRequest<IResponse>
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
