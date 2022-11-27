namespace CreditRelease.API.Utility
{
    public static class EndpointsUtils
    {
        public const string BASE_ROUTE_Cliente = "/Cliente";
        public const string Route_Cliente_POST = $"{BASE_ROUTE_Cliente}/CreateCliente";
        public const string Route_Cliente_GetByID = $"{BASE_ROUTE_Cliente}/GetCliente/{{id}}";
        public const string Route_Cliente_GetAll = $"{BASE_ROUTE_Cliente}/GetCliente";
        public const string Route_Cliente_PUT = $"{BASE_ROUTE_Cliente}/UpdateCliente/{{id}}";
        public const string Route_Cliente_DELETE = $"{BASE_ROUTE_Cliente}/DeleteCliente/{{id}}";

        public const string BASE_ROUTE_Financiamento = "/Financiamento";
        public const string Route_Financiamento_POST = $"{BASE_ROUTE_Financiamento}/CreateFinanciamento";
        public const string Route_Financiamento_GetByID = $"{BASE_ROUTE_Financiamento}/GetFinanciamento/{{id}}";
        public const string Route_Financiamento_GetAll = $"{BASE_ROUTE_Financiamento}/GetFinanciamento";
        public const string Route_Financiamento_PUT = $"{BASE_ROUTE_Financiamento}/UpdateFinanciamento/{{id}}";
        public const string Route_Financiamento_DELETE = $"{BASE_ROUTE_Financiamento}/DeleteFinanciamento/{{id}}";

        public const string BASE_ROUTE_Parcela = "/Parcela";
        public const string Route_Parcela_POST = $"{BASE_ROUTE_Parcela}/CreateParcela";
        public const string Route_Parcela_GetByID = $"{BASE_ROUTE_Parcela}/GetParcela/{{id}}";
        public const string Route_Parcela_GetAll = $"{BASE_ROUTE_Parcela}/GetParcela";
        public const string Route_Parcela_PUT = $"{BASE_ROUTE_Parcela}/UpdateParcela/{{id}}";
        public const string Route_Parcela_DELETE = $"{BASE_ROUTE_Parcela}/DeleteParcela/{{id}}";
    }
}
