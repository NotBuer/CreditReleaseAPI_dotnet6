namespace CreditRelease.Domain.Entities
{
    public class Cliente : IEntity
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? UF { get; set; }
        public long Celular { get; set; }
        public ICollection<Financiamento>? Financiamentos { get; set; }
    }
}
