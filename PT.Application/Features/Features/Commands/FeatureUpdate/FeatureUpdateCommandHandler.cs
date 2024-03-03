using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Features.Commands.FeatureUpdate
{
    public class FeatureUpdateCommandHandler : IRequestHandler<FeatureUpdateCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public FeatureUpdateCommandHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(FeatureUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<Feature>();
                var feature = await _projectTracker.FeatureRepository.GetById<Feature>(tableName, request.Id);
                if (feature is null)
                {
                    response.NotFound(SharedMessages.FEATURE_NOT_FOUND);
                    return response;
                }

                await _projectTracker.FeatureRepository.Update(tableName, request);
                _projectTracker.Commit();

                response.Message = GenericReplyMessages.SUCCESS_OPERATION;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(FeatureUpdateCommandHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
