using Bimeh.Domain.Requests.Dtos;
using Bimeh.Domain.Requests.Entities;

namespace Bimeh.Domain.Requests.Contracts
{
    public interface IReqeustsQueryRepository
    {
        Task<IEnumerable<Request>> GetAllAsync();
        Task<List<CalculationRequestDto>> GetAsync(long id);
    }
}
