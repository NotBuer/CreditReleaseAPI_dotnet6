namespace CreditRelease.API.Utility
{
    public static class EndpointsUtils
    {
        public const string BASE_Cliente = "/Cliente";
        public const string Route_Cliente_POST = $"{BASE_Cliente}/CreateCliente";
        public const string Route_Cliente_GetByID = $"{BASE_Cliente}/GetCliente/{{id}}";
        public const string Route_Cliente_GetAll = $"{BASE_Cliente}/GetCliente";
        public const string Route_Cliente_PUT = $"{BASE_Cliente}/UpdateCliente/{{id}}";
        public const string Route_Cliente_DELETE = $"{BASE_Cliente}/DeleteCliente/{{id}}";

        public const string BASE_Financiamento = "/Financiamento";
        public const string Route_Financiamento_POST = $"{BASE_Financiamento}/CreateFinanciamento";
        public const string Route_Financiamento_GetByID = $"{BASE_Financiamento}/GetFinanciamento/{{id}}";
        public const string Route_Financiamento_GetAll = $"{BASE_Financiamento}/GetFinanciamento";
        public const string Route_Financiamento_GetUniqueFinanciamentoByClienteID = $"{BASE_Financiamento}/GetFinanciamento/ByCliente/Unique/{{id}}/{{idCliente}}";
        public const string Route_Financiamento_GetFinanciamentosByClienteID = $"{BASE_Financiamento}/GetFinanciamento/ByCliente/All/{{idCliente}}";
        public const string Route_Financiamento_PUT = $"{BASE_Financiamento}/UpdateFinanciamento/{{id}}";
        public const string Route_Financiamento_DELETE = $"{BASE_Financiamento}/DeleteFinanciamento/{{id}}";

        public const string BASE_Parcela = "/Parcela";
        public const string Route_Parcela_POST = $"{BASE_Parcela}/CreateParcela";
        public const string Route_Parcela_POSTMany = $"{BASE_Parcela}/CreateParcela/PostMany";
        public const string Route_Parcela_GetByID = $"{BASE_Parcela}/GetParcela/{{id}}";
        public const string Route_Parcela_GetAll = $"{BASE_Parcela}/GetParcela";
        public const string Route_Parcela_GetUniqueParcelaByFinanciamentoID = $"{BASE_Parcela}/GetParcela/ByFinanciamento/Unique/{{id}}/{{idFinanciamento}}";
        public const string Route_Parcela_GetParcelasByFinanciamentoID = $"{BASE_Parcela}/GetParcela/ByFinanciamento/All/{{idFinanciamento}}";
        public const string Route_Parcela_PUT = $"{BASE_Parcela}/UpdateParcela/{{id}}";
        public const string Route_Parcela_DELETE = $"{BASE_Parcela}/DeleteParcela/{{id}}";

        public const string BASE_ProcessCredit = "/Credit";
        public const string Route_ProcessCredit_POST = $"{BASE_ProcessCredit}/ProcessCreditRelease";
    }
}
