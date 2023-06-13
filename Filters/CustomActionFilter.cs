using managemoney.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace managemoney.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter, IOrderedFilter
    {
        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // if (context.Controller.Equals(typeof(LancamentoController)))
            // {
            //     context.Result = new ContentResult
            //     {
            //         Content = 
            //     }
            // };
        }
    }
}