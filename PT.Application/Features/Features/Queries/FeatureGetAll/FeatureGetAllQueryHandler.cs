using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Features.Queries.FeatureGetAll
{
    public class FeatureGetAllQueryHandler : IRequestHandler<FeatureGetAllQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public FeatureGetAllQueryHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(FeatureGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<List<Feature>>();

            try
            {
                var tableName = EntityToTable.Convert<Feature>();
                response.Data = await _projectTracker.FeatureRepository.GetAll<Feature>(tableName);
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(FeatureGetAllQueryHandler), ex.Message);
            }

            return response;
        }
    }
}
