using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMBusinessLayer
{

    public interface IEmployee
    {
        int EmployeeId { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        int DepartmentID { get; set; }
        DateTime? DateOfBirth { get; set; }
    }
    public class BuisnessLibEmployee: IEmployee
    {
        [Required]
        public int EmployeeId { get; set; }

        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
         public DateTime? DateOfBirth { get; set; }
    }
}
