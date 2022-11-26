namespace CreditRelease.Domain.Entities
{
    public class Financiamento : IEntity
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string? CPF { get; set; }
        public string? TipoFinanciamento { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime UltimoVencimento { get; set; }
        public ICollection<Parcela>? Parcelas { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
