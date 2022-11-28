namespace CreditRelease.Domain.Rules
{
    public static class BusinessRules
    {
        public const decimal MAX_ALLOWED_VALUE = 1000000.00m;
        public const decimal MIN_ALLOWED_VALUE_PJ = 15000.00m;

        public const byte MIN_INSTALLMENTS = 5;
        public const byte MAX_INSTALLMENTS = 72;

        public const byte FIRST_DUE_DATE_FROM = 15;
        public const byte LAST_DUE_DATE_FROM = 40;

        public const decimal TAX_CREDIT_Direto = 2.0m;
        public const decimal TAX_CREDIT_Consignado = 1.0m;
        public const decimal TAX_CREDIT_PJ = 5.0m;
        public const decimal TAX_CREDIT_CPF = 3.0m;
        public const decimal TAX_CREDIT_Imobiliario = 9.0m;

        public static decimal ReturnTaxForSpecificCreditType(TypeCreditEnum typeCredit) => typeCredit switch
        {
            TypeCreditEnum.CreditoDireto => TAX_CREDIT_Direto,
            TypeCreditEnum.CreditoConsignado => TAX_CREDIT_Consignado,
            TypeCreditEnum.CreditoPJ => TAX_CREDIT_PJ,
            TypeCreditEnum.CreditoCPF => TAX_CREDIT_CPF,
            TypeCreditEnum.CreditoImobiliario => TAX_CREDIT_Imobiliario,
            _ => throw new ArgumentOutOfRangeException(nameof(typeCredit), $"Not expected typeCredit value: {typeCredit}"),
        };
    }
}
