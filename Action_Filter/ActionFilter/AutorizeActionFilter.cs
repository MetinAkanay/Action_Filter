using Action_Filter.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Action_Filter.ActionFilter
{
    public class AutorizeActionFilter:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Girilen action ve controlleri bulalım
            string controller = context.RouteData.Values["Controller"].ToString();
            string action = context.RouteData.Values["Action"].ToString();

            // Sessiondan değerleri alalım
            if(context.HttpContext.Session.Keys.Count() != 0) { 
                string sessionController = context.HttpContext.Session.GetString("Controller");
                string sessionAction = context.HttpContext.Session.GetString("Action");

                if (sessionAction != action || sessionController != controller)
                {
                    var controllerbase = (HomeController)context.Controller;
                    context.Result = controllerbase.RedirectToAction("Error","Home");
                }
            }
        }

    }
}
