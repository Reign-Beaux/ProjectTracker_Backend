using MediatR;
using PT.Application.Features.Users;
using PT.Application.Features.Users.Commands.UserDelete;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Users.Users.Commands.UserDelete
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public UserDeleteCommandHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                var user = await _projectTracker.UsersRepository.GetById<User>(tableName, request.Id);
                if (user is null)
                {
                    response.NotFound(UsersMessages.USER_NOT_FOUND);
                    return response;
                }

                await _projectTracker.UsersRepository.Delete<User>(tableName, request.Id);
                _projectTracker.Commit();
                response.Message = GenericReplyMessages.SUCCESS_OPERATION;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserDeleteCommandHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
