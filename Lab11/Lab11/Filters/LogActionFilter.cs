using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters
{
    public class LogActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            var actionName = filterContext.ActionDescriptor.DisplayName;
            var timeOfApplication = DateTime.Now;

            File.AppendAllText("logAction.txt", $"Action name: {actionName}, and time of application: {timeOfApplication} {Environment.NewLine}");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) { }
    }
}
