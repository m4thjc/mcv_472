using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_472_PortfolioC.Models
{
    [Table("tblDepartment")]
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public bool? IsSelected { get; set; }
        public List<Employee> Employees { get; set; }
    }
}