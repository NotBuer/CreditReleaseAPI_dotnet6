namespace CreditRelease.Domain.Entities
{
    public class Cliente : IEntity
    {
        [Required] public int Id { get; set; }
        [Required] public string? Nome { get; set; }
        [Required] public string? CPF { get; set; }
        [Required] public string? UF { get; set; }
        [Required] public long Celular { get; set; }

        [JsonIgnore]
        public ICollection<Financiamento>? Financiamentos { get; set; }
    }
}
