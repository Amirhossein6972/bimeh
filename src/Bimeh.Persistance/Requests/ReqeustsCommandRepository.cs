using Bimeh.Domain.Requests.Contracts;
using Bimeh.Domain.Requests.Entities;

namespace Bimeh.Persistance.Requests
{
    public class ReqeustsCommandRepository : IReqeustsCommandRepository
    {
        private readonly BimehCommandDbContext _dbContext;

        public ReqeustsCommandRepository(BimehCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Request request)
        {
            await _dbContext.Requests.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }
    }
}
