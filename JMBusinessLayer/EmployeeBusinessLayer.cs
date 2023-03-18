using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JMBusinessLayer
{
    public class EmployeeBusinessLayer
    {

        public IEnumerable<BuisnessLibEmployee> Employees
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                List<BuisnessLibEmployee> employees = new List<BuisnessLibEmployee>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BuisnessLibEmployee employee = new BuisnessLibEmployee();
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.City = rdr["City"].ToString();
                        employee.DepartmentID = Convert.ToInt32(rdr["DepartmentID"]);
                        employees.Add(employee);
                    }
                
                
                } 

                return employees;
            }


        }
    }
}
