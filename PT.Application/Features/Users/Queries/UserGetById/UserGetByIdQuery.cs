using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Users.Queries.UserGetById
{
    public class UserGetByIdQuery : IRequest<IResponse>
    {
        public int Id { get; set; }

        public UserGetByIdQuery(int? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
