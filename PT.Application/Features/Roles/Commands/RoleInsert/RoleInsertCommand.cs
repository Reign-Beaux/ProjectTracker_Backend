using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Roles.Commands.RoleInsert
{
    public class RoleInsertCommand : IRequest<IResponse>
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
