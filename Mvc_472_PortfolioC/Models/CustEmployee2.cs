using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Mvc_472_PortfolioC.Models
{
    [MetadataType(typeof(Employee2MetaData))]
    [DisplayColumn("FullName")]
    public partial class Employee2
    {
        
    }
   
    public class Employee2MetaData
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yy}")]
        public DateTime HireDate { get; set; }

        [DisplayFormat(NullDisplayText ="Gender not specifed")]
        public string Gender { get; set; }

        [DataType(DataType.Currency)]
        [ScaffoldColumn(false)]
        public int? Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [DataType(DataType.Url)]
        public string PersonalWebSite { get; set; }
    }

}