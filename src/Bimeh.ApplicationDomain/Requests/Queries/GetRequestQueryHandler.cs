using Bimeh.Domain.Requests.Contracts;
using Bimeh.Domain.Requests.Dtos;
using Bimeh.Domain.Requests.Queries;
using MediatR;

namespace Bimeh.ApplicationDomain.Requests.Queries
{
    public class GetRequestQueryHandler : IRequestHandler<GetRequestQuery, List<CalculationRequestDto>>
    {
        private readonly IReqeustsQueryRepository _reqeustsQueryRepository;

        public GetRequestQueryHandler(IReqeustsQueryRepository reqeustsQueryRepository)
        {
            _reqeustsQueryRepository = reqeustsQueryRepository;
        }

        public async Task<List<CalculationRequestDto>> Handle(GetRequestQuery requestQuery, CancellationToken cancellationToken)
        {
            var request = await _reqeustsQueryRepository.GetAsync(requestQuery.Id);
            if (request == null)
            {
                throw new Exception("request not found");
            }

            return request;
        }
    }
}
