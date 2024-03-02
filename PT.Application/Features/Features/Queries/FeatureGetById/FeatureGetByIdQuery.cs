using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Features.Queries.FeatureGetById
{
    public class FeatureGetByIdQuery : IRequest<IResponse>
    {
        public int Id { get; set; }

        public FeatureGetByIdQuery(int? id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
