using AutoMapper;
using MediatR;
using PT.Application.Features.Users.Helpers;
using PT.Application.Helpers;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;

namespace PT.Application.Features.Users.Commands.UserInsert
{
    public class UserInsertCommandHandler : IRequestHandler<UserInsertCommand, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly IMapper _mapper;
        private readonly LogManagementService _logManagement;

        public UserInsertCommandHandler(IUnitOfWorkProjectTracker projectTracker, IMapper mapper, LogManagementService logManagement)
        {
            _projectTracker = projectTracker;
            _mapper = mapper;
            _logManagement = logManagement;
        }

        public async Task<IResponse> Handle(UserInsertCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();

            try
            {
                var tableName = EntityToTable.Convert<User>();
                var parameters = _mapper.Map<UserInsertPayload>(request);
                var fullname = $"{request.Name} {request.PaternalLastname} {request.MaternalLastname}" ;
                parameters.Password = BCryptHelper.EncriptText(request.Password);
                parameters.Username = CreateUser.Handle(fullname);
                await _projectTracker.UsersRepository.Insert(tableName, parameters);
                _projectTracker.Commit();
                response.Message = GenericReplyMessages.SUCCESS_OPERATION;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserInsertCommandHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }
    }
}
