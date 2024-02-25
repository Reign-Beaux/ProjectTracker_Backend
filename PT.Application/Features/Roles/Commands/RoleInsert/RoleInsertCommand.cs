using MediatR;

namespace PT.Application.Features.Roles.Commands.RoleInsert
{
    public class RoleInsertCommand : IRequest
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
