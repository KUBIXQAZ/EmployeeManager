using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.DTOs;
using EmployeeManager.Services;
using Microsoft.Data.SqlClient;

namespace EmployeeManager.Models
{
    public class EmployeeModel
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();  

            using(SqlConnection sqlConnection = new SqlConnection(App.ConnectionString))
            {
                sqlConnection.Open();

                string query = "SELECT * FROM Employees;";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                
                using(SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int id = int.Parse(reader["Id"].ToString());
                        string name = reader["Name"].ToString();
                        string surname = reader["Surname"].ToString();
                        string email = reader["Email"].ToString();
                        string phone = reader["Phone"].ToString();
                        string pesel = reader["pesel"].ToString();

                        Employee employee = new Employee(id,name,surname,email,phone,pesel);
                            
                        employees.Add(employee);
                    }
                }

                sqlConnection.Close();

                return employees;
            }
        }
    }
}
