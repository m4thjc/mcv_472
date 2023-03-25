using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_472_PortfolioC.Models
{
    public class Company
    {
        private string _name;

        public Company()
        {
        }

        public Company(string name)
        {
            this._name = name;
        }

        public string SelectedDepartment { get; set; }

        public List<Department> Departments
        {
            get
            {
                EmployeeContext db = new EmployeeContext();
                return db.Departments.ToList();
            }
        }

        public string CompanyName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}