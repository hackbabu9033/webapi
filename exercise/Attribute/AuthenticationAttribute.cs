using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;

namespace exercise.Attribute
{
    ///// <summary>
    ///// override to process unauthorized request
    ///// </summary>
    //public class AuthenticationAttribute : AuthorizeAttribute
    //{
    //    protected override void HandleUnauthorizedRequest(HttpActionContext httpActionContext)
    //    {
    //        if (!HttpContext.Current.User.Identity.IsAuthenticated)
    //        {
    //            base.HandleUnauthorizedRequest(httpActionContext);
    //        }
    //        else
    //        {
    //            httpActionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
    //        }
    //    }
    //}
}