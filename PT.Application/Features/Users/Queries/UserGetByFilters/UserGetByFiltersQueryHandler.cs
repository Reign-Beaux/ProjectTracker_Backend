using AutoMapper;
using MediatR;
using PT.Application.Features.Users.Queries.UserGetById;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;
using System.Collections.Generic;

namespace PT.Application.Features.Users.Queries.UserGetByFilters
{
    public class UserGetByFiltersQueryHandler : IRequestHandler<UserGetByFiltersQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;
        private readonly IMapper _mapper;

        public UserGetByFiltersQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement, IMapper mapper)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(UserGetByFiltersQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<List<UserGetByFiltersQueryResponse>>();

            try
            {
                List<User> users = await _projectTracker.UsersRepository.GetByFilters(request);
                var data = FillData(users);

                response.Data = data;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserGetByIdQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }

        private List<UserGetByFiltersQueryResponse> FillData(List<User> users)
        {
            List<UserGetByFiltersQueryResponse> data = new();

            foreach (var user in users)
            {
                data.Add(_mapper.Map<UserGetByFiltersQueryResponse>(user));
            }

            return data;
        }
    }
}
