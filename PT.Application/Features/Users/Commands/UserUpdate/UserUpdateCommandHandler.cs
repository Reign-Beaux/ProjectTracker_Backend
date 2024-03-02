using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Users.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public UserUpdateCommandHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                var currentUser = await _projectTracker.UsersRepository.GetById<User>(tableName, request.Id);

                if (currentUser is null)
                {
                    await _responseManagement.NotFound(response, typeof(UserUpdateCommandHandler), "Usuario no encontrado");
                    return response;
                }

                await _projectTracker.UsersRepository.Update(tableName, request);
                _projectTracker.Commit();
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(UserUpdateCommandHandler), ex.Message);
            }

            return response;
        }
    }
}
