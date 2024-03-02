using MediatR;
using PT.Application.Features.Users.Commands.UserDelete;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Users.Users.Commands.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public UserDeleteCommandHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                var currentUser = await _projectTracker.UsersRepository.GetById<User>(tableName, request.Id);

                if (currentUser is null)
                {
                    await _responseManagement.NotFound(response, typeof(UserDeleteCommandHandler), "User no encontrado");
                    return response;
                }

                await _projectTracker.UsersRepository.Delete<User>(tableName, request.Id);
                _projectTracker.Commit();
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(UserDeleteCommandHandler), ex.Message);
            }

            return response;
        }
    }
}
