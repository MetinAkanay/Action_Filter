using Microsoft.AspNetCore.Mvc.Filters;

namespace Action_Filter.ActionFilter
{
    public class CustomLoggingActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString();
            string action = context.RouteData.Values["action"].ToString();
            StreamWriter writer = new StreamWriter("c:\\log\\log.txt", true);
            writer.WriteLine(controller+" içerisindeki "+action+" isimli metod çağırıldı. ");
            writer.Close();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
