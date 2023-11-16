using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters
{
    public class UniqueUsersFilter : Attribute, IActionFilter
    {
        static HashSet<string> uniqueUsers = new HashSet<string>();

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ipAddress = filterContext.HttpContext.Connection.RemoteIpAddress;
            uniqueUsers.Add(ipAddress.ToString());

            File.WriteAllText("uniqueUsers.txt", $"Total unique users: {uniqueUsers.Count}, and ip address: {ipAddress}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
