
namespace Bimeh.Domain.Requests.Dtos
{
    public class CalculationRequestDto
    {
        public string CoverageTitle { get; set; }
        public int CoverageId { get; set; }
        public long Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal Result { get; set; }
    }

    public class RequestDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long AmountSum { get; set; }
    }
}
