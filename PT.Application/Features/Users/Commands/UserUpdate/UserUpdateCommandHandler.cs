using AutoMapper;
using MediatR;
using PT.Application.Features.Users.Helpers;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;

namespace PT.Application.Features.Users.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly IMapper _mapper;
        private readonly LogManagementService _logManagement;

        public UserUpdateCommandHandler(IUnitOfWorkProjectTracker projectTracker, IMapper mapper, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _mapper = mapper;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
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
                var parameters = _mapper.Map<UserUpdateParameters>(request);
                var fullname = $"{request.Name} {request.PaternalLastname} {request.MaternalLastname}";
                parameters.Username = CreateUser.Handle(fullname);
                await _projectTracker.UsersRepository.Update(tableName, parameters);
                _projectTracker.Commit();
                response.Message = GenericReplyMessages.SUCCESS_OPERATION;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserUpdateCommandHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
