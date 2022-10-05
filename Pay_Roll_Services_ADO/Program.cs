using System;

namespace Pay_Roll_Services_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to Employee Payroll");
            EmployeeRepository repo = new EmployeeRepository();
            repo.GetAllEmployee();
        }
    }
}
