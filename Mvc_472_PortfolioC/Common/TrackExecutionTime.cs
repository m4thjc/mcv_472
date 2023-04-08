using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Mvc_472_PortfolioC.Common
{
    public class TrackExecutionTime : ActionFilterAttribute, IExceptionFilter
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor +
                " -> " + filterContext.ActionDescriptor.ActionName + " -> OnActionExecuting \t- " +
                DateTime.Now.ToString() + "\n";

            LogExecutionTime(message);

           
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message =  filterContext.ActionDescriptor.ControllerDescriptor +
                " -> " + filterContext.ActionDescriptor.ActionName + " -> OnActionExecuted \t- " +
                DateTime.Now.ToString() + "\n";

            LogExecutionTime(message);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string message = filterContext.RouteData.Values["Controller"] +
                " -> " + filterContext.RouteData.Values["action"] + " -> OnResultExecuting \t- " +
                DateTime.Now.ToString() + "\n";

            LogExecutionTime(message);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string message = filterContext.RouteData.Values["Controller"] +
                " -> " + filterContext.RouteData.Values["action"] + " -> OnResultExecuted \t- " +
                DateTime.Now.ToString() + "\n";

            LogExecutionTime(message);
            LogExecutionTime("----------------------------------------------------------");
        }


        private void LogExecutionTime(string data)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Data/Data.txt"), data);
        }

        public void OnException(ExceptionContext filterContext)
        {
            string message = filterContext.RouteData.Values["Controller"] +
                " -> " + filterContext.RouteData.Values["action"] + " " + filterContext.Exception.Message +  " -> OnResultExecuted \t- " + DateTime.Now.ToString() + "\n";

            LogExecutionTime(message);
            LogExecutionTime("----------------------------------------------------------");
        }
    }
}