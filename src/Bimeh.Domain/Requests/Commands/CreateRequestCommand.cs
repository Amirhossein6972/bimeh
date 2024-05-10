using Bimeh.Domain.Requests.Dtos;
using MediatR;

namespace Bimeh.Domain.Requests.Commands
{
    public class CreateRequestCommand : IRequest<List<CalculationRequestDto>>
    {
        public string Title { get; set; }
        public List<CoverageCapital> CoverageCapitals { get; set; }

        public class CoverageCapital
        {
            public int CoverageId { get; set; }
            public long Amount { get; set; }
        }
    }
}
