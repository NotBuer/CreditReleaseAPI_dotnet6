using CreditRelease.Domain.Common;

namespace CreditRelease.Domain.Entities
{
    public class Financiamento : IEntity
    {
        [Required] public int Id { get; set; }
        [Required] public int IdCliente { get; set; }
        public string? CPF { get; set; }
        [Required] public TypeCreditEnum TipoFinanciamento { get; set; }
        [Required] public decimal ValorTotal { get; set; }
        public decimal ValorTotalComTaxa { get; set; }
        [Required] public decimal ValorTaxa { get; set; }
        public StatusCreditEnum StatusCredito { get; set; }
        [Required] public byte QuantidadeParcelas { get; set; }
        [Required] public DateTime DataContratacao { get; set; }
        [Required] public DateTime VencimentoPrimeiraParcela { get; set; }
        public DateTime? UltimoVencimento { get; set; }

        public ICollection<Parcela>? Parcelas { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
