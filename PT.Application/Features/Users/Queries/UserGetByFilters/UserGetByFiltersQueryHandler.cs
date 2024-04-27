using MediatR;
using PT.Application.Features.Users.Queries.UserGetById;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Users.Queries.UserGetByFilters
{
    public class UserGetByFiltersQueryHandler : IRequestHandler<UserGetByFiltersQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public UserGetByFiltersQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(UserGetByFiltersQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<List<User>>();

            try
            {
                var users = await _projectTracker.UsersRepository.GetByFilters(request);
                response.Data = users;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserGetByIdQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
