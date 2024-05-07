using AutoMapper;
using MediatR;
using PT.Application.Features.Users.Queries.UserGetById;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;
using PT.Infraestructure.Persistence.ProjectTracker.Users.Models;
using System.Xml.Linq;

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
                var payload = FillPayload(request);
                List<User> users = await _projectTracker.UsersRepository.GetByFilters(payload);
                var data = FillData(users);

                response.Data = data;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserGetByIdQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }

        private static UserGetByFiltersPayload FillPayload(UserGetByFiltersQuery request)
        {
            return new UserGetByFiltersPayload
            {
                UserName = request.UsersFilter.UserName,
                Name = request.UsersFilter.Name,
                PaternalLastName = request.UsersFilter.PaternalLastName,
                MaternalLastname = request.UsersFilter.MaternalLastname,
                Email = request.UsersFilter.Email,
                PageSize = request.Pagination.PageSize,
                PageNumber = request.Pagination.Page + 1,
                OrderBy = request.Sort[0].Field,
                SortDirection = request.Sort[0].Sort,
            };
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
