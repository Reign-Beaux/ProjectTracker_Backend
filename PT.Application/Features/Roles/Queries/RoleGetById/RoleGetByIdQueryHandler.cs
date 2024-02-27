using MediatR;
using PT.Application.Models.Responses;
using PT.Domain.ProjectTracker;
using PT.Infraestructure.Persistence.ProjectTracker.UnitOfWork;

namespace PT.Application.Features.Roles.Queries.RoleGetById
{
    public class RoleGetByIdQueryHandler : IRequestHandler<RoleGetByIdQuery, IResponse>
    {
        private readonly IUnitOfWorkProjectTracker _projectTracker;

        public RoleGetByIdQueryHandler(IUnitOfWorkProjectTracker projectTracker)
        {
            _projectTracker = projectTracker;
        }

        public async Task<IResponse> Handle(RoleGetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseData<Role>();

            try
            {
                //response.Data = await _projectTracker.RolesRepository.GetById<Role>(request.Id) ?? throw new Exception("");
            }
            catch (Exception ex)
            {
                
            }

            return response;
        }
    }
}
