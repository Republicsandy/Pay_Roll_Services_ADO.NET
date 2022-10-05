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
                            employeeModel.Name = sqlDataReader.GetString(1);
                            employeeModel.BasicPay = sqlDataReader.GetDouble(2);
                            employeeModel.StartDate = sqlDataReader.GetDateTime(3);
                            employeeModel.Gender = sqlDataReader.GetString(4);
                            employeeModel.Phone = sqlDataReader.GetInt32(5);
                            employeeModel.Department = sqlDataReader.GetString(6);
                            employeeModel.Address = sqlDataReader.GetString(7);
                            employeeModel.Deductions = sqlDataReader.GetDouble(8);
                            employeeModel.TaxblePay = sqlDataReader.GetDouble(9);
                            employeeModel.IncomeTax = sqlDataReader.GetDouble(10);
                            employeeModel.NetPay = sqlDataReader.GetDouble(11);
                            Console.WriteLine("{0}      {1}       {2}       {3}       {4}       {5}       {6}       {7}     {8}     {9}    {10}    {11}", employeeModel.EmployeeId, employeeModel.Name, employeeModel.BasicPay, employeeModel.StartDate, employeeModel.Gender, employeeModel.Phone, employeeModel.Department, employeeModel.Address, employeeModel.Deductions, employeeModel.TaxblePay, employeeModel.IncomeTax, employeeModel.NetPay);
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
                sqlConnection.Close();
            }
        }

        public string UpdateEmployee(EmployeePayRoll employeeModel)
        {
            string change = "Not success";
            try
            {
                using (sqlConnection)
                {
                    //Open command with spUpdateEmployeeDetails 
                    string query = @"update employee_payroll set BasicPay = '300000' where EmployeeId = '3' and EmployeeName = 'Priya'";
                    SqlCommand command = new SqlCommand(query, this.sqlConnection);
                    //open connection
                    sqlConnection.Open();
                    //executes the query and returns the no of rows the changes are reflected
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                        change = "success";

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                sqlConnection.Close();

            }
            return change;


        }
    }
}
