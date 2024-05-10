namespace Bimeh.Domain.Requests.Entities
{
    public class InsuranceCalculation
    {
        private InsuranceCalculation() { }
        public InsuranceCalculation(decimal rate, long amount)
        {
            Rate = rate;
            Result = amount * rate;
        }

        public long Id { get; set; }
        public long RequestCoverageId { get; set; }
        public decimal Rate { get; set; }
        public decimal Result { get; set; }

        public RequestCoverage RequestCoverage { get; set; }
    }
}
