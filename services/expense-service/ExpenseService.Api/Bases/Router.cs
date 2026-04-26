namespace ExpenseService.Api.Bases
{
    public static class Router
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public const string ByIdRoute = "/{id}";

        // ================= User Financial Profile Routes =================
        public static class UserFinancialProfileRouting
        {
            public const string Prefix = Base + "/financial-profile";
            public const string Create = Prefix;                  // POST: api/v1/financial-profile
        }

    }
}
