using AutoMapper;
using MediatR;
using PT.Application.Features.Users.Queries.UserGetByFilters;
using PT.Application.Features.Users.Queries.UserGetById;
using PT.Application.Models.Responses;
using PT.Application.Services.Logger;
using PT.Application.Static;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.Roles.Models;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Queries.RoleGetByFilters
{
    public class RoleGetByFiltersQueryHandler : IRequestHandler<RoleGetByFiltersQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;
        private readonly LogManagementService _logManagement;
        private readonly IMapper _mapper;

        public RoleGetByFiltersQueryHandler(IUnitOfWorkProjectTracker projectTracker, LogManagementService logManagement, IMapper mapper)
        {
            _projectTracker = projectTracker;
            _logManagement = logManagement;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(RoleGetByFiltersQuery request, CancellationToken cancellationToken)
        {
            ResponseData<List<Role>> response = new();

            try
            {
                var payload = FillPayload(request);
                List<Role> roles = await _projectTracker.RolesRepository.GetByFilters(payload);
                response.Data = roles;
            }
            catch (Exception ex)
            {
                await _logManagement.InsertLog(typeof(UserGetByIdQueryHandler), StatusResponse.INTERNAL_SERVER_ERROR, ex.Message);
            }

            return response;
        }

        public static RoleGetByFiltersPayload FillPayload(RoleGetByFiltersQuery request)
        {
            return new()
            {
                Code = request.RolesFilter.Code,
                Name = request.RolesFilter.Name,
                PageSize = request.Pagination.PageSize,
                PageNumber = request.Pagination.Page + 1,
                OrderBy = request.Sort.Field,
                SortDirection = request.Sort.Sort,
            };
        }
    }
}
