using Bimeh.Domain.Coverages.Contratcs;
using Bimeh.Domain.Requests.Commands;
using Bimeh.Domain.Requests.Contracts;
using Bimeh.Domain.Requests.Dtos;
using Bimeh.Domain.Requests.Entities;
using MediatR;

namespace Bimeh.ApplicationDomain.Requests.Commands
{
    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, List<CalculationRequestDto>>
    {
        private readonly IReqeustsCommandRepository _reqeustsCommandRepository;
        private readonly ICoverageCommandRepository _coverageCommandRepository;

        public CreateRequestCommandHandler(IReqeustsCommandRepository reqeustsCommandRepository, ICoverageCommandRepository coverageCommandRepository)
        {
            _reqeustsCommandRepository = reqeustsCommandRepository;
            _coverageCommandRepository = coverageCommandRepository;
        }

        public async Task<List<CalculationRequestDto>> Handle(CreateRequestCommand commandRequest, CancellationToken cancellationToken)
        {
            var result = new List<CalculationRequestDto>();

            if (!commandRequest.CoverageCapitals.Any())
            {
                throw new Exception("coverage not valid");
            }

            var request = new Request(commandRequest.Title);

            foreach (var coverage in commandRequest.CoverageCapitals)
            {

                var findCoverage = await _coverageCommandRepository.GetByIdAsync(coverage.CoverageId);
                if (findCoverage == null)
                {
                    throw new Exception("coverage not found");
                }

                if (coverage.Amount > findCoverage.MaxCapital || coverage.Amount < findCoverage.MinCapital)
                {
                    throw new Exception("coverage amount not valid");
                }


                var resultAmount = request.AddCoverage(coverage.CoverageId, coverage.Amount, findCoverage.Rate);

                result.Add(new CalculationRequestDto { Amount = coverage.Amount, CoverageId = coverage.CoverageId, Rate = findCoverage.Rate, CoverageTitle = findCoverage.Title, Result = resultAmount });
            }

            await _reqeustsCommandRepository.AddAsync(request);

            return result;
        }
    }
}
