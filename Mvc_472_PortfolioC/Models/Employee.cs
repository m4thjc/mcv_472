using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mvc_472_PortfolioC.Models
{



    [Table("tblEmployee")]
    public class Employee
    {
        public Employee() { }
        public Employee(int _employeeId, string _name, string _gender, string _city, int _departmentId, DateTime? _dateOfBirth)
        {
            EmployeeId = _employeeId;
            Name = _name;
            Gender = _gender;
            City = _city;
            DepartmentID = _departmentId;
            DateOfBirth = _dateOfBirth;
    }
        [Required]
        public int EmployeeId { get; set; }

        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string City { get; set; }
        [Required]
        [Range(1,500)]
        public int DepartmentID { get; set; }
        [Required]
        [Range(typeof(DateTime), "01/01/1940","1/1/2020")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
    }
}