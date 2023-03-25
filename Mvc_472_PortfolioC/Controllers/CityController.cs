using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Mvc_472_PortfolioC.Models;

namespace Mvc_472_PortfolioC.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        [HttpGet]
        [ActionName("Index")]
        public ActionResult IndexGet()
        {

            SampleEntities dbContext = new SampleEntities();

            var cities = dbContext.Cities;
            return View(cities);
        }

        [HttpPost]
        [ActionName("Index")]
        public string IndexPost(IEnumerable<City> cities)
        {
            if (cities.Count(x => (bool)x.IsSelected) == 0)
            {
                return "You didn't select any Cities";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - ");
                foreach (City city in cities)
                {
                    if ((bool)city.IsSelected)
                    {
                        sb.Append(city.Name + ", ");
                    }
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString();
            }
        }
    }
}