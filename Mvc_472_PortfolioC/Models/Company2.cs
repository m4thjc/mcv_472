using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_472_PortfolioC.Models
{
    public class Company2
    {
        public Employee2 CompanyDirector
        {
            get
            {
                Sample2 dbContext = new Sample2();
                return dbContext.Employee2.Single(x => x.Id == 1);
            }
        }
    }
}