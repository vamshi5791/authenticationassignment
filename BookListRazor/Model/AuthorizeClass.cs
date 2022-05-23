using Microsoft.AspNetCore.Mvc.Filters;

namespace BookListRazor.Model
{
    public class AuthorizeMe : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int a = 100;
        }
    }
}
