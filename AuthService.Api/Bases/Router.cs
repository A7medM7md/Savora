namespace AuthService.Api.Bases
{
    public static class Router
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public const string ByIdRoute = "/{id}";

        // ================= User Routes =================
        public static class UserRouting
        {
            public const string Prefix = Base + "/users";
            public const string Create = Prefix;                  // POST: api/v1/users
            public const string PaginatedList = Prefix + "/paginated";      // GET: api/v1/users/paginated?
            public const string GetById = Prefix + ByIdRoute;     // GET: api/v1/users/{id}
            public const string Update = Prefix + ByIdRoute;      // PUT: api/v1/users/{id}
            public const string Delete = Prefix + ByIdRoute;      // DELETE: api/v1/users/{id}
            public const string ChangePassword = Prefix + "/changePassword" + ByIdRoute;      // PUT: api/v1/users/changePassword/{id}

        }

        // ================= AuthN Routes =================
        public static class AuthenticationRouting
        {
            public const string Prefix = Base + "/authentication";
            public const string SignIn = Prefix + "/signin";
            public const string SignInWithGoogle = Prefix + "/signin/google";
            public const string Register = Prefix + "/register";
            public const string RefreshToken = Prefix + "/refresh";
            public const string ValidateToken = Prefix + "/validate";
            public const string ConfirmEmail = Prefix + "/confirm-email";
            public const string SendResetPasswordCode = Prefix + "/send-reset-password-code";
            public const string VerifyResetPasswordCode = Prefix + "/verify-reset-password-code";
            public const string ResetPassword = Prefix + "/reset-password";
        }

        // ================= AuthZ Routes =================
        public static class AuthorizationRouting
        {
            public const string RolePrefix = Base + "/roles";
            public const string ClaimPrefix = Base + "/claims";
            public const string UserPrefix = Base + "/users";

            // Roles
            public const string GetRoles = RolePrefix; // GET: api/v1/roles
            public const string GetRoleById = RolePrefix + ByIdRoute; // GET: api/v1/roles/{id}
            public const string AddRole = RolePrefix; // POST: api/v1/roles
            public const string EditRole = RolePrefix + ByIdRoute; // PUT: api/v1/roles/{id}
            public const string DeleteRole = RolePrefix + ByIdRoute; // DELETE: api/v1/roles/{id}

            // User Roles
            public const string GetUserRoles = UserPrefix + ByIdRoute + "/roles"; // GET: api/v1/users/{id}/roles
            public const string AssignRole = UserPrefix + ByIdRoute + "/roles"; // POST: api/v1/users/{id}/roles
            public const string UpdateUserRoles = UserPrefix + ByIdRoute + "/roles"; // PUT: api/v1/users/{id}/roles
            public const string RevokeUserRole = UserPrefix + ByIdRoute + "/roles" + "/{roleId}"; // DELETE: api/v1/users/{id}/roles/{roleId}

            // User Claims
            public const string GetUserClaims = UserPrefix + ByIdRoute + "/claims"; // GET: api/v1/users/{id}/claims
            public const string UpdateUserClaims = UserPrefix + ByIdRoute + "/claims"; // PUT: api/v1/users/{id}/claims


        }


        // ================= Email Routes =================
        public static class EmailRouting
        {
            public const string Prefix = Base + "/emails";

            public const string Send = Prefix; // POST: api/v1/emails

        }

        // ================= Lead Routes =================
        public static class LeadRouting
        {
            public const string Prefix = Base + "/leads";
            public const string Create = Prefix;                            // POST: api/v1/leads
            public const string PaginatedList = Prefix + "/paginated";      // GET: api/v1/leads/paginated?
            public const string GetAll = Prefix;                            // GET: api/v1/leads
            public const string GetById = Prefix + ByIdRoute;               // GET: api/v1/leads/{id}
            public const string Update = Prefix + ByIdRoute;                // PUT: api/v1/leads/{id}
            public const string Delete = Prefix + ByIdRoute;                // DELETE: api/v1/leads/{id}
        }

        // ================= Customer Routes =================
        public static class CustomerRouting
        {
            public const string Prefix = Base + "/customers";
            public const string Create = Prefix;                            // POST: api/v1/customers
            public const string PaginatedList = Prefix + "/paginated";      // GET: api/v1/customers/paginated?
            public const string GetAll = Prefix;                            // GET: api/v1/customers
            public const string GetById = Prefix + ByIdRoute;               // GET: api/v1/customers/{id}
            public const string Update = Prefix + ByIdRoute;                // PUT: api/v1/customers/{id}
            public const string Delete = Prefix + ByIdRoute;                // DELETE: api/v1/customers/{id}

        }

        // ================= Opportunity Routes =================
        public static class OpportunityRouting
        {
            public const string Prefix = Base + "/opportunities";
            public const string Create = Prefix;                  // POST: api/v1/opportunities
            public const string PaginatedList = Prefix + "/paginated";      // GET: api/v1/opportunities/paginated?
            public const string GetAll = Prefix;                            // GET: api/v1/opportunities
            public const string GetById = Prefix + ByIdRoute;     // GET: api/v1/opportunities/{id}
            public const string Update = Prefix + ByIdRoute;      // PUT: api/v1/opportunities/{id}
            public const string Delete = Prefix + ByIdRoute;      // DELETE: api/v1/opportunities/{id}

        }


    }
}
