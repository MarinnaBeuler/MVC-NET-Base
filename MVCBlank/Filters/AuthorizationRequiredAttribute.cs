using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MVCBlank.Filters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains("Token"))
            {
                string tokenVal = actionContext.Request.Headers.GetValues("Token").First();
                string hardcodedTokenCheck = "shake_and_bake";// have this be a string from database to compare
                if(tokenVal != hardcodedTokenCheck)
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                    {
                        ReasonPhrase = "Tokens do not match!"
                    };
                }
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                {
                    ReasonPhrase = "No token found."
                };
            }
            base.OnActionExecuting(actionContext);
        }
    }
}