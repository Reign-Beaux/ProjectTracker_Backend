using MediatR;
using PT.Application.Models.Responses;

namespace PT.Application.Features.Features.Commands.FeatureInsert
{
    public class FeatureInsertCommand : IRequest<IResponse>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
    }
}
