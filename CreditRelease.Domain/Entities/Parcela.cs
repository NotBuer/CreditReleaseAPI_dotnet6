namespace CreditRelease.Domain.Entities
{
    public class Parcela : IEntity
    {
        [Required] public int Id { get; set; }
        [Required] public int IdFinanciamento { get; set; }
        [Required] public byte NumeroDaParcela { get; set; }
        [Required] public decimal ValorDaParcela { get; set; }
        [Required] public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }

        public Financiamento? Financiamento { get; set; }
    }
}
