using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Features.Commands.FeatureDelete
{
    public class FeatureDeleteCommand : IRequest<IResponse>
    {
        public int Id { get; set; }

        public FeatureDeleteCommand(int? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
