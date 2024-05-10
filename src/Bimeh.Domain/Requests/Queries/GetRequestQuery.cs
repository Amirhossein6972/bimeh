using Bimeh.Domain.Requests.Dtos;
using MediatR;

namespace Bimeh.Domain.Requests.Queries
{
    public class GetRequestQuery : IRequest<List<CalculationRequestDto>>
    {
        public GetRequestQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
