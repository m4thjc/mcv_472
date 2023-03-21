using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_472_PortfolioC.Models
{
    [MetadataType(typeof(EfEmployeeMetaData))]
    public partial class EfEmployee
    {
    }

    public class EfEmployeeMetaData
    {
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}