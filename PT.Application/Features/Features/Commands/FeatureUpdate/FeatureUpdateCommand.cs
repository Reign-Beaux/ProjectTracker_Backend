using MediatR;
using PT.Application.Services.ResponseManagement.Models;
using PT.Domain.ProjectTracker;

namespace PT.Application.Features.Features.Commands.FeatureUpdate
{
    public class FeatureUpdateCommand : Feature, IRequest<IResponse>
    {
    }
}
