using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Users.Queries.UserGetAll
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;

        public UserGetAllQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<List<User>>();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                response.Data = await _projectTracker.UsersRepository.GetAll<User>(tableName);
                response.Message = GenericReplyMessages.QUERY_SUCCESS;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserGetAllQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
