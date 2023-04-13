﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Mvc_472_PortfolioC.Common
{
    public class RemoteClientServerAttribute : RemoteAttribute
    {
        public RemoteClientServerAttribute(string routeName) 
            : base(routeName)
        {
        }

        public RemoteClientServerAttribute(string action, string controller)
            : base(action, controller)
        {
        }
        public RemoteClientServerAttribute(string action, string controller, string areaName)
            : base(action, controller, areaName)
        {
        }



        public override bool IsValid(object value)
        {
            Type controller = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(type => type.Name.ToLower() == string.Format("{0}Controller", this.RouteData["controller"].ToString().ToLower()));
            
            if(controller != null)
            {
                MethodInfo action = controller.GetRuntimeMethods().FirstOrDefault(method => method.Name.ToLower() == this.RouteData["action"].ToString().ToLower());
                if(action != null)
                {
                    object instance = Activator.CreateInstance(controller);
                    object response = action.Invoke(instance, new object[] { value });

                    if(response is JsonResult)
                    {
                        object jsonData = ((JsonResult)response).Data;
                        if(jsonData is bool)
                        {
                                return (bool)jsonData;
                        }
                    }
                }
            }
            return true;


        }
    }
}