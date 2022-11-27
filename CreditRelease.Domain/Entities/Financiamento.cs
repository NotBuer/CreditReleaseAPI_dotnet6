namespace CreditRelease.Domain.Entities
{
    public class Financiamento : IEntity
    {
        [Required] public int Id { get; set; }
        [Required] public int IdCliente { get; set; }
        [Required] public string? CPF { get; set; }
        [Required] public string? TipoFinanciamento { get; set; }
        [Required] public decimal ValorTotal { get; set; }
        [Required] public DateTime UltimoVencimento { get; set; }

        [JsonIgnore]
        public ICollection<Parcela>? Parcelas { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; }
    }
}
