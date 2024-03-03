using MediatR;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Features.Queries.FeatureGetById
{
    public class FeatureGetByIdQuery : IRequest<IResponse>
    {
        public int Id { get; set; }

        public FeatureGetByIdQuery(int? id = null)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
