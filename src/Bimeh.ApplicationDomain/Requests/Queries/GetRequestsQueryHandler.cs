using Bimeh.Domain.Requests.Contracts;
using Bimeh.Domain.Requests.Dtos;
using Bimeh.Domain.Requests.Queries;
using MediatR;

namespace Bimeh.ApplicationDomain.Requests.Queries
{
    public class GetRequestsQueryHandler : IRequestHandler<GetRequestsQuery, List<RequestDto>>
    {
        private readonly IReqeustsQueryRepository _reqeustsQueryRepository;

        public GetRequestsQueryHandler(IReqeustsQueryRepository reqeustsQueryRepository)
        {
            _reqeustsQueryRepository = reqeustsQueryRepository;
        }

        public async Task<List<RequestDto>> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
        {
            var items = await _reqeustsQueryRepository.GetAllAsync();

            var result = items.Select(x => new RequestDto { Id = x.Id, Title = x.Title, AmountSum = x.AmountSum() }).ToList();

            return result;
        }
    }
}
