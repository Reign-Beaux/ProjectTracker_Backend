using AutoMapper;
using MediatR;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Users.Queries.UserGetById
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;
        private readonly IMapper _mapper;

        public UserGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement, IMapper mapper)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<UserGetByIdQueryResponse>();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                var user = await _projectTracker.UsersRepository.GetById<User>(tableName, request.Id);
                if (user is null)
                {
                    response.NotFound(UsersMessages.USER_NOT_FOUND);
                    return response;
                }

                response.Data = _mapper.Map<UserGetByIdQueryResponse>(user);
                response.Data.Password = string.Empty;
                response.Message = GenericReplyMessages.QUERY_SUCCESS;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserGetByIdQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
