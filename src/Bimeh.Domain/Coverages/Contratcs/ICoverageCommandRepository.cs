using Bimeh.Domain.Coverages.Entities;

namespace Bimeh.Domain.Coverages.Contratcs
{
    public interface ICoverageCommandRepository
    {
        Task<Coverage> GetByIdAsync(int coverageId);
    }
}
