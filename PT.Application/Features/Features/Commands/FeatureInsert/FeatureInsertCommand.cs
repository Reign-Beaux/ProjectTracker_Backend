using MediatR;
using PT.Application.Services.ResponseManagement.Models;

namespace PT.Application.Features.Features.Commands.FeatureInsert
{
    public class FeatureInsertCommand : IRequest<IResponse>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
    }
}
