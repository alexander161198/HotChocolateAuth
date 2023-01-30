using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using HotChocolateAuthTest.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HotChocolateAuthTest.Interceptors
{
    public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
    {
        public override ValueTask OnCreateAsync(HttpContext context,
            IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder,
            CancellationToken cancellationToken)
        {
            if (context.GetUser().Identity.IsAuthenticated)
            {
                requestBuilder.SetProperty("currentUser",
                    new CurrentUser(Guid.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                        context.User.Claims.Select(x => $"{x.Type} : {x.Value}").ToList()));
            }

            return base.OnCreateAsync(context, requestExecutor, requestBuilder,
                cancellationToken);
        }
    }
}
