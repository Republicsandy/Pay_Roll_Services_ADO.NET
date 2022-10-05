using System;

namespace Pay_Roll_Services_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to Employee Payroll");
            EmployeeRepository repo = new EmployeeRepository();
            EmployeeRepository employeeRepo1 = new EmployeeRepository();
            repo.GetAllEmployee();
            EmployeePayRoll model = new EmployeePayRoll();
            model.Name = "Sandeep singh";
            model.EmployeeId = 3;
            model.BasicPay = 300000;
            employeeRepo1.UpdateEmployee(model);
            repo.GetAllEmployee();
        }
    }
}
