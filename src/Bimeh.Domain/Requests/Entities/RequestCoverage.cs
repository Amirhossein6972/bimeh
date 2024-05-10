namespace Bimeh.Domain.Requests.Entities
{
    public class RequestCoverage
    {
        private RequestCoverage() { }
        public RequestCoverage(int coverageId, long amount, decimal rate)
        {
            CoverageId = coverageId;
            Amount = amount;
            InsuranceCalculation = new InsuranceCalculation(rate, amount);
        }

        public long Id { get; set; }
        public long RequestId { get; set; }
        public int CoverageId { get; set; }
        public long Amount { get; set; }

        public Request Request { get; set; }
        public InsuranceCalculation InsuranceCalculation { get; set; }

        public decimal ShowResult()
        {
            return InsuranceCalculation.Result;
        }
    }
}
