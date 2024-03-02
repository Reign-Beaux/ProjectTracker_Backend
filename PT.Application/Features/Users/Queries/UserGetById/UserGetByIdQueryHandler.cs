using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Users.Queries.UserGetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public UserGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<User?>();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                response.Data = await _projectTracker.UsersRepository.GetById<User>(tableName, request.Id);
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(UserGetByIdQueryHandler), ex.Message);
            }

            return response;
        }
    }
}
