using Bimeh.Domain.Requests.Dtos;
using MediatR;

namespace Bimeh.Domain.Requests.Queries
{
    public class GetRequestsQuery : IRequest<List<RequestDto>>
    {
    }
}
