using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Bakey.Web.IdentityExtention
{
    public static class IdentityExtension
    {
        public static string GetRole(this IIdentity identity)
        {
            if (identity != null)
            {
                var ci = identity as ClaimsIdentity;

                var claim = ci.FindFirst(ClaimsIdentity.DefaultRoleClaimType);
                string role = string.Empty;
                if(claim!=null)
                    role = claim.Value;

                return role;

            }

            return string.Empty;
        }

    }
}