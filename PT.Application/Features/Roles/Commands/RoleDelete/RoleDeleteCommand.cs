using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Roles.Commands.RoleDelete
{
    public class RoleDeleteCommand : IRequest<IResponse>
    {
        public int Id { get; set; }

        public RoleDeleteCommand(int? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
