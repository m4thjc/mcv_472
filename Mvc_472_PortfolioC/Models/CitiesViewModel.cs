using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_472_PortfolioC.Models
{
    public class CitiesViewModel
    {
        public IEnumerable<SelectListItem> Cites { get; set; }
        public IEnumerable<string> SelectedCities { get; set; }
    }
}