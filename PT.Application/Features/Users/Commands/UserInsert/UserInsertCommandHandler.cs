using MediatR;
using PT.Application.Services.ResponseManagement;
using PT.Application.Services.ResponseManagement.Models;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Users.Commands.UserInsert
{
    public class UserInsertCommandHandler : IRequestHandler<UserInsertCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly ResponseManagementService _responseManagement;

        public UserInsertCommandHandler(IUnitOfWorkProjectTracker projectTracker, ResponseManagementService responseManagement)
        {
            _projectTracker = projectTracker;
            _responseManagement = responseManagement;
        }

        public async Task<IResponse> Handle(UserInsertCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                await _projectTracker.UsersRepository.Insert(tableName, request);
                _projectTracker.Commit();
            }
            catch (Exception ex)
            {
                await _responseManagement.InteralServerError(response, typeof(UserInsertCommandHandler), ex.Message);
            }

            return response;
        }
    }
}
