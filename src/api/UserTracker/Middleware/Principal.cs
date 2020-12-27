using System.Security.Principal;

namespace UserTracker.Middleware
{
    public class Principal : GenericPrincipal
    {
        public Principal(IIdentity identity, string[] roles) : base(identity, roles)
        {
        }
    }
}