using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace QAForum.API
{
    public class CustomAuthorizeFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                string email;
                if (!TryRetrieveEmail(actionContext.Request, out email) || string.IsNullOrWhiteSpace(email))
                {
                    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
                }

                // create an identity with the valid claims.
                ClaimsIdentity identity = new ClaimsIdentity(new List<Claim>
                {
                        new Claim(ClaimTypes.Email, email)
                }, "google");

                // set the context principal.
                actionContext.RequestContext.Principal = new ClaimsPrincipal(new[] { identity });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        private static bool TryRetrieveEmail(HttpRequestMessage request, out string email)
        {
            email = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("x-email", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            email = authzHeaders.ElementAt(0);
            return true;
        }
    }
}