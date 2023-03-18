using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_472_PortfolioC.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        public Employee() { }
        public Employee(int _employeeId, string _name, string _gender, string _city, int _departmentId)
        {
            EmployeeId = _employeeId;
            Name = _name;
            Gender = _gender;
            City = _city;
            DepartmentID = _departmentId;
    }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int DepartmentID { get; set; }
    }
}