using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Features.Queries.FeatureGetById
{
    public class FeatureGetByIdQueryHandler : IRequestHandler<FeatureGetByIdQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public FeatureGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(FeatureGetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<Feature?>();

            try
            {
                var tableName = EntityToTable.Convert<Feature>();
                response.Data = await _projectTracker.FeatureRepository.GetById<Feature>(tableName, request.Id);
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(FeatureGetByIdQueryHandler), ex.Message);
            }

            return response;
        }
    }
}
