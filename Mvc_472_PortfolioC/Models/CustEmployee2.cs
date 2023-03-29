using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_472_PortfolioC.Models
{
    [MetadataType(typeof(Employee2MetaData))]
    [DisplayColumn("FullName")]
    public partial class Employee2
    {
        
    }
   
    public class Employee2MetaData
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yy}")]
        public DateTime HireDate { get; set; }

        [DisplayFormat(NullDisplayText ="Gender not specifed")]
        public string Gender { get; set; }

        [DataType(DataType.Currency)]
        [ScaffoldColumn(false)]
        public int? Salary { get; set; }

        [ReadOnly(true)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [DataType(DataType.Url)]
        [UIHint("OpenInNewWindow")]
        public string PersonalWebSite { get; set; }
    }

}