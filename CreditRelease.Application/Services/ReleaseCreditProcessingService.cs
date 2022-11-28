namespace CreditRelease.Application.Services
{
    public class ReleaseCreditProcessingService : IReleaseCreditProcessingService
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly FinanciamentoRepository _financiamentoRepository;
        private readonly ParcelaRepository _parcelaRepository;

        public ReleaseCreditProcessingService(ClienteRepository clienteRepository, FinanciamentoRepository financiamentoRepository, ParcelaRepository parcelaRepository)
        {
            _clienteRepository = clienteRepository;
            _financiamentoRepository = financiamentoRepository;
            _parcelaRepository = parcelaRepository;
        }

        public async Task<Financiamento> CreateAndProcessFinanciamentoForCliente(int idCliente, Financiamento financiamento)
        {
            // Insert the financiamento data in the DbSet.
            _financiamentoRepository.CreateFinanciamento(financiamento);

            // Validate financiamento input parameters based on business logic.
            if (financiamento.ValorTotal > BusinessRules.MAX_ALLOWED_VALUE)
                financiamento.StatusCredito = StatusCreditEnum.Recused;

            if (financiamento.QuantidadeParcelas < BusinessRules.MIN_INSTALLMENTS || financiamento.QuantidadeParcelas > BusinessRules.MAX_INSTALLMENTS)
                financiamento.StatusCredito = StatusCreditEnum.Recused;

            if (financiamento.TipoFinanciamento == TypeCreditEnum.CreditoPJ
                && financiamento.ValorTotal < BusinessRules.MIN_ALLOWED_VALUE_PJ)
                financiamento.StatusCredito = StatusCreditEnum.Recused;

            if ((financiamento.VencimentoPrimeiraParcela < (financiamento.DataContratacao.AddDays(BusinessRules.FIRST_DUE_DATE_FROM))
               || financiamento.VencimentoPrimeiraParcela > (financiamento.DataContratacao.AddDays(BusinessRules.LAST_DUE_DATE_FROM))))
                financiamento.StatusCredito = StatusCreditEnum.Recused;

            // Validate the type of credit and get the taxes from it.
            financiamento.ValorTaxa = BusinessRules.ReturnTaxForSpecificCreditType(financiamento.TipoFinanciamento);
            financiamento.ValorTotalComTaxa = ((financiamento.ValorTotal / 100) * financiamento.ValorTaxa) + financiamento.ValorTotal;

            if (financiamento.StatusCredito != StatusCreditEnum.Recused)
            {
                // Validate parcelas input parameters based on business logic.
                decimal valorParcela = financiamento.ValorTotalComTaxa / financiamento.QuantidadeParcelas;
                Parcela primeiraParcela = new();
                List<Parcela> parcelasParaAdicionar = new();
                for (byte i = 0; i < financiamento.QuantidadeParcelas; i++)
                {

                    // Primeira parcela exclusive
                    if (i == 0)
                    {
                        primeiraParcela.IdFinanciamento = financiamento.Id;
                        primeiraParcela.NumeroDaParcela = i;
                        primeiraParcela.ValorDaParcela = valorParcela;
                        primeiraParcela.DataVencimento = financiamento.VencimentoPrimeiraParcela;
                        primeiraParcela.DataPagamento = null;
                        primeiraParcela.ParcelaPaga = false;

                        parcelasParaAdicionar.Add(primeiraParcela);
                        continue;
                    }

                    Parcela parcela = new Parcela
                    {
                        IdFinanciamento = financiamento.Id,
                        NumeroDaParcela = i,
                        ValorDaParcela = valorParcela,
                        DataVencimento = primeiraParcela.DataVencimento.AddMonths(i),
                        DataPagamento = null,
                        ParcelaPaga = false,
                    };

                    parcelasParaAdicionar.Add(parcela);
                }

                // Insert the parcelas data in the DbSet.
                await _parcelaRepository.CreateManyParcelas(parcelasParaAdicionar);

                // Update the financiamento parcelas collection.
                financiamento.Parcelas = parcelasParaAdicionar;

                // Retrieve the cliente data from DbSet.
                Cliente? cliente = await _clienteRepository.GetClienteById(idCliente);
                if (cliente != null)
                {
                    financiamento.IdCliente = cliente.Id;
                    financiamento.CPF = cliente.CPF;
                    financiamento.Cliente = cliente;
                }

                // Update the credit status, and update it data in the DbSet.
                financiamento.StatusCredito = StatusCreditEnum.Approved;
                _financiamentoRepository.UpdateFinanciamento(financiamento);
            }

            return financiamento;
        }
    }
}