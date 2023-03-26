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
            List<SelectListItem> listSelectListItem = new List<SelectListItem>();

            foreach(City city in dbContext.Cities)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.ID.ToString(),
                    Selected = city.IsSelected
                };
                listSelectListItem.Add(selectListItem);
            }

            CitiesViewModel citiesViewModel = new CitiesViewModel();
            citiesViewModel.Cites = listSelectListItem;

            //This was for old checkbox code 
            //var cities = dbContext.Cities;

            return View(citiesViewModel);
        }

        [HttpPost]
        [ActionName("Index")]
        public string IndexPost(IEnumerable<string> selectedCities)
        {
            if (selectedCities == null)
            {
                return "You didn't select any Cities";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - ");
                foreach (string city in selectedCities)
                {
                    sb.Append(city + ", ");
                }

                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                return sb.ToString();
            }
        }

        //Checkbox version
        //[HttpPost]
        //[ActionName("Index")]
        //public string IndexPost(IEnumerable<City> cities)
        //{
        //    if (cities.Count(x => (bool)x.IsSelected) == 0)
        //    {
        //        return "You didn't select any Cities";
        //    }
        //    else
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("You selected - ");
        //        foreach (City city in cities)
        //        {
        //            if ((bool)city.IsSelected)
        //            {
        //                sb.Append(city.Name + ", ");
        //            }
        //        }
        //        sb.Remove(sb.ToString().LastIndexOf(","), 1);
        //        return sb.ToString();
        //    }
        //}
    }
}