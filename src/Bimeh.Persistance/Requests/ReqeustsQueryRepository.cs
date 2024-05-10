using Bimeh.Domain.Requests.Contracts;
using Bimeh.Domain.Requests.Dtos;
using Bimeh.Domain.Requests.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bimeh.Persistance.Requests
{
    public class ReqeustsQueryRepository : IReqeustsQueryRepository
    {
        private readonly BimehCommandDbContext _dbContext;

        public ReqeustsQueryRepository(BimehCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Request>> GetAllAsync()
        {
            return Task.FromResult(_dbContext.Requests.Include(x => x.Coverages).AsNoTracking().AsEnumerable());
        }

        public async Task<List<CalculationRequestDto>> GetAsync(long id)
        {
            var query = await (from req in _dbContext.Requests
                               join reqCov in _dbContext.RequestCoverages on req.Id equals reqCov.RequestId
                               join inCal in _dbContext.InsuranceCalculations on reqCov.Id equals inCal.RequestCoverageId
                               join cov in _dbContext.Coverages on reqCov.CoverageId equals cov.Id

                               where req.Id == id

                               select new CalculationRequestDto
                               {
                                   Amount = reqCov.Amount,
                                   CoverageId = reqCov.CoverageId,
                                   CoverageTitle = cov.Title,
                                   Rate = inCal.Rate,
                                   Result = inCal.Result
                               }).ToListAsync();

            return query;
        }
    }
}
