﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EcommerceApplication
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            string message = $"\nTime: {DateTime.Now}, Controller: {controllerName}, Action: {actionName}, Exception: {context.Exception.Message}";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Log.txt");
            //saving the data in a text file called Log.txt
            File.AppendAllText(filePath, message);

            context.Result = new ViewResult
            {
                ViewName = "Error"
            };
            context.ExceptionHandled = true;
        }
    }
}
