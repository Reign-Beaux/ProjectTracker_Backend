using MediatR;
using PT.Application.Models.Responses;

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
