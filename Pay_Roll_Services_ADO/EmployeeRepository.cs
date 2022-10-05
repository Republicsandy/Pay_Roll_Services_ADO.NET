using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Reflection;

namespace Pay_Roll_Services_ADO
{
     public class EmployeeRepository
    {
        //Data Source=REPUBLIC\MSSQL;Initial Catalog=PayRollService;Integrated Security=True
        public static string connectionString = @"Server=REPUBLIC\MSSQL;Database=PayRollService;Trusted_Connection=True;";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void GetAllEmployee()
        {
           
            try
            {
                //Employee Model object 
                EmployeePayRoll employeeModel = new EmployeePayRoll();
                using (sqlConnection)
                {
                    //query execution
                    string query = @"Select * from employee_payroll";
                    SqlCommand command = new SqlCommand(query, this.sqlConnection);
                    //open sql connection
                    this.sqlConnection.Open();
                    //sql reader to read data from db
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            employeeModel.EmployeeId = sqlDataReader.GetInt32(0);
                            employeeModel.EmployeeName = sqlDataReader.GetString(1);
                            Console.WriteLine("{0} {1}", employeeModel.EmployeeId, employeeModel.EmployeeName);
                        }

                    }
                    //close reader
                    sqlDataReader.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

    }
}
