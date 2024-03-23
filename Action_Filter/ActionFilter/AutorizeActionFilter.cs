using Action_Filter.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Action_Filter.ActionFilter
{
    public class AutorizeActionFilter:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Girilen action ve controlleri bulalım
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();

            // Sessiondan değerleri alalım
            if(context.HttpContext.Session.Keys.Count() != 0) { 
                string sessionController = context.HttpContext.Session.GetString("controller");
                string sessionAction = context.HttpContext.Session.GetString("action");

                if (sessionAction != action || sessionController != controller)
                {
                    if(controller == "Home" && action == "Error")
                    {

                    }
                    else
                    {
                        var controllerbase = (HomeController)context.Controller;
                        context.Result = controllerbase.RedirectToAction("Error","Home");
                    }
                    
                }
            }
        }

    }
}
