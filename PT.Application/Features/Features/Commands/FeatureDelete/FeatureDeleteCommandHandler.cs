using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Features.Commands.FeatureDelete
{
    public class FeatureDeleteCommandHandler : IRequestHandler<FeatureDeleteCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public FeatureDeleteCommandHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(FeatureDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<Feature>();
                var currentFeature = await _projectTracker.FeatureRepository.GetById<Feature>(tableName, request.Id);

                if (currentFeature is null)
                {
                    await _responseManagement.NotFound(response, typeof(FeatureDeleteCommandHandler), "Feature no encontrada");
                    return response;
                }

                await _projectTracker.FeatureRepository.Delete<Feature>(tableName, request.Id);
                _projectTracker.Commit();
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(FeatureDeleteCommandHandler), ex.Message);
            }

            return response;
        }
    }
}
