using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace RazorPagesDemoApp.CRUD.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DisablePostMethodFilter : Attribute, IPageFilter
    {
        // Called after the handler method executes, before the action result.
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {            
        }

        // Called before the handler method executes, after model binding is complete.
        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (context.HandlerMethod.HttpMethod == "Post"  && context.RouteData.Values.TryGetValue("id", out _))
            {
                context.Result = new ContentResult { Content = "Post method is not allowed at the moment" };
            }
        }

        // Called after a handler method has been selected, but before model binding occurs.
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {            
        }
    }
}
