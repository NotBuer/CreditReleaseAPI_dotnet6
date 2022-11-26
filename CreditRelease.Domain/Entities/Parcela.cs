namespace CreditRelease.Domain.Entities
{
    public class Parcela : IEntity
    {
        public int Id { get; set; }
        public int IdFinanciamento { get; set; }
        public byte NumeroDaParcela { get; set; }
        public decimal ValorDaParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public Financiamento? Financiamento { get; set; }
    }
}
