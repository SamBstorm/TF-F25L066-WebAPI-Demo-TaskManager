
using TaskManager.DAL.Services;

namespace TaskManager.API.Handlers.RouteConstraints
{
    public class ApiKeyRouteConstraint : IRouteConstraint
    {
        private readonly string[] _validApiKeys = ["Toto","Titi","Tutu"];

        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.ContainsKey("ApiKey")){
                return _validApiKeys.Contains(values["ApiKey"]!.ToString()!);
            }
            else
            {
                return false;
            }
        }
    }
}
