using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_472_PortfolioC.Models
{
    [MetadataType(typeof(EfCustDepartmentMetaData))]
    public partial class EfDepartment
    {

    }
    public class EfCustDepartmentMetaData
    {
        [Display(Name = "Department Name")]
        public string Name { get; set; }
    }
}