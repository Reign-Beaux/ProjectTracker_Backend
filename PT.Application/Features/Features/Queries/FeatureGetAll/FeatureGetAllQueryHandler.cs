using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Features.Queries.FeatureGetAll
{
    public class FeatureGetAllQueryHandler : IRequestHandler<FeatureGetAllQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public FeatureGetAllQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(FeatureGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<List<Feature>>();

            try
            {
                var tableName = EntityToTable.Convert<Feature>();
                response.Data = await _projectTracker.FeatureRepository.GetAll<Feature>(tableName);
                response.Message = GenericReplyMessages.QUERY_SUCCESS;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLogger(typeof(FeatureGetAllQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
