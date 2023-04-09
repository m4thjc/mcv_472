using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc_472_PortfolioC.Common
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimumValue) 
            : base(typeof(DateTime), minimumValue, DateTime.Now.ToShortDateString()) { }
    }
}