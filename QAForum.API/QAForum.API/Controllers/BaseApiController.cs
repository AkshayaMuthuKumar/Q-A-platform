using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace QAForum.API.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public string UserId => this.GetUserId();

        private string GetUserId()
        {
            var identity = User.Identity as ClaimsIdentity;
           return identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        }
    }
}
