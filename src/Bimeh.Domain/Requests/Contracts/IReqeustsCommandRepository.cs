using Bimeh.Domain.Requests.Entities;

namespace Bimeh.Domain.Requests.Contracts
{
    public interface IReqeustsCommandRepository
    {
        Task AddAsync(Request request);
    }
}
