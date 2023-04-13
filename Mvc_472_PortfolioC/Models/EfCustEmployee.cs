using Mvc_472_PortfolioC.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_472_PortfolioC.Models
{
    [MetadataType(typeof(EfEmployeeMetaData))]
    public partial class EfEmployee
    {
        [System.ComponentModel.DataAnnotations.Compare("City")]
        public string ConfirmCity { get; set; }
    }

    public class EfEmployeeMetaData
    {
        //[Remote("IsUserNameAvailable", "EfEmployees", ErrorMessage = "That name is taken.")]
        [RemoteClientServer("IsUserNameAvailable", "EfEmployees", ErrorMessage = "That name is taken.")]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Please enter a valid City name")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        //[DateRange("01/01/1940")]
        [CurrentDate]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }
}