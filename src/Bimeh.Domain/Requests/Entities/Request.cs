
namespace Bimeh.Domain.Requests.Entities
{
    public class Request
    {
        private Request() { }
        public Request(string title)
        {
            Title = title;
            Coverages = new List<RequestCoverage>();
        }

        public long Id { get; set; }
        public string Title { get; set; }

        public ICollection<RequestCoverage> Coverages { get; set; }


        public decimal AddCoverage(int coverageId, long amount, decimal rate)
        {
            var item = new RequestCoverage(coverageId, amount, rate);

            Coverages.Add(item);

            return item.ShowResult();
        }

        public long AmountSum()
        {
            long sum = 0;
            foreach (var item in Coverages)
            {
                sum += item.Amount;
            }

            return sum;
        }
    }
}
