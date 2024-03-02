using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Features.Commands.FeatureUpdate
{
    public class FeatureUpdateCommandHandler : IRequestHandler<FeatureUpdateCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public FeatureUpdateCommandHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(FeatureUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<Feature>();
                var currentFeature = await _projectTracker.FeatureRepository.GetById<Feature>(tableName, request.Id);

                if (currentFeature is null)
                {
                    await _responseManagement.NotFound(response, typeof(FeatureUpdateCommandHandler), "Feature no encontrado");
                    return response;
                }

                await _projectTracker.FeatureRepository.Update(tableName, request);
                _projectTracker.Commit();
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(FeatureUpdateCommandHandler), ex.Message);
            }

            return response;
        }
    }
}
