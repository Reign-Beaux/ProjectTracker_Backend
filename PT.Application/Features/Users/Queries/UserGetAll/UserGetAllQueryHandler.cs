using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Users.Queries.UserGetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public UserGetAllQueryHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<List<User>>();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                response.Data = await _projectTracker.UsersRepository.GetAll<User>(tableName);
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(UserGetAllQueryHandler), ex.Message);
            }

            return response;
        }
    }
}
