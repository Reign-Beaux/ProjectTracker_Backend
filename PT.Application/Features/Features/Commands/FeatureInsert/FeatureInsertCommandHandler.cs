using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Features.Commands.FeatureInsert
{
    public class FeatureInsertCommandHandler : IRequestHandler<FeatureInsertCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public FeatureInsertCommandHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(FeatureInsertCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<Feature>();
                await _projectTracker.FeatureRepository.Insert(tableName, request);
                _projectTracker.Commit();
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(FeatureInsertCommandHandler), ex.Message);
            }

            return response;
        }
    }
}
