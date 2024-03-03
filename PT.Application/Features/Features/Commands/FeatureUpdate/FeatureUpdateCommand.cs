using MediatR;
using PT.Application.Models.Responses;
using PT.Domain.ProjectTracker;

namespace PT.Application.Features.Features.Commands.FeatureUpdate
{
    public class FeatureUpdateCommand : Feature, IRequest<IResponse>
    {
    }
}
