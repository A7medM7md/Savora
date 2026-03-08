using System.Security.Claims;

namespace AuthService.Domain.Helpers.AuthZ
{
    public static class ClaimsStore
    {
        public static List<Claim> claims = new()
        {
            new Claim("Can Create Student","false"),
            new Claim("Can Edit Student","false"),
            new Claim("Can Delete Student","false"),
        };
    }
}
