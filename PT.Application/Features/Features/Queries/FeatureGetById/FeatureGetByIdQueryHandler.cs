using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Features.Queries.FeatureGetById
{
    public class FeatureGetByIdQueryHandler : IRequestHandler<FeatureGetByIdQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public FeatureGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(FeatureGetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<Feature?>();

            try
            {
                var tableName = EntityToTable.Convert<Feature>();
                var feature = await _projectTracker.FeatureRepository.GetById<Feature>(tableName, request.Id);
                if (feature is null)
                {
                    response.NotFound(SharedMessages.FEATURE_NOT_FOUND);
                    return response;
                }

                response.Data = feature;
                response.Message = GenericReplyMessages.QUERY_SUCCESS;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLogger(typeof(FeatureGetByIdQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
