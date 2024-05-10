namespace Bimeh.Domain.Coverages.Entities
{
    public class Coverage
    {
        private Coverage() { }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Rate { get; set; }
        public long MaxCapital { get; set; }
        public long MinCapital { get; set; }
    }
}
