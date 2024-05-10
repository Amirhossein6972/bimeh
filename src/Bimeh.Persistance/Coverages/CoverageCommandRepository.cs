using Bimeh.Domain.Coverages.Contratcs;
using Bimeh.Domain.Coverages.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bimeh.Persistance.Coverages
{
    public class CoverageCommandRepository : ICoverageCommandRepository
    {
        private readonly BimehCommandDbContext _dbContext;

        public CoverageCommandRepository(BimehCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Coverage> GetByIdAsync(int coverageId) => await _dbContext.Coverages.FirstOrDefaultAsync(x => x.Id == coverageId);
    }
}
